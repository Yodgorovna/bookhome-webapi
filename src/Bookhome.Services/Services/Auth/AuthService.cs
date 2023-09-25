using Bookhome.Application.Exceptions;
using Bookhome.Application.Exceptions.Auth;
using Bookhome.Application.Exceptions.Users;
using Bookhome.DataAcces.Interfaces.Users;
using Bookhome.Services.Helpers;
using Bookhome.Services.Interfaces.Auth;
using Bookhome.Services.Interfaces.Notifications;
using Bookhome.Services.Security;
using BookHome.Domain.Entities.Users;
using BookHome.Domain.Enums;
using BookHome.Persistance.Dtos.Auth;
using BookHome.Persistance.Dtos.Notifications;
using BookHome.Persistance.Dtos.Security;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;

namespace Bookhome.Services.Services.Auth;
public class AuthService : IAuthService
{
    private const int CACHED_FOR_MINUTS_REGISTER = 60;
    private const int CACHED_FOR_MINUTS_VERIFICATION = 1;
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 5;

    private const string REGISTER_CACHE_KEY = "register_";
    private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
    private const string Reset_CACHE_KEY = "reset_";

    private readonly ITokenService _tokenService;
    private readonly ISmsSender _smsSender;
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepository _userRepository;

    public AuthService(
        IMemoryCache memoryCache,
        IUserRepository userRepository,
        ITokenService tokenService,
        ISmsSender smsSender,
        IConfiguration configuration)
    {
        this._tokenService = tokenService;
        this._smsSender = smsSender;
        this._memoryCache = memoryCache;
        this._userRepository = userRepository;
    }
    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(RegisterDto dto)
    {
        var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
        if (user is not null) throw new UserAlreadyExistsException(dto.PhoneNumber);

        // delete if exists user by this phone number
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.PhoneNumber, out RegisterDto cachedRegisterDto))
        {
            cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
            _memoryCache.Remove(REGISTER_CACHE_KEY + dto.PhoneNumber);
        }
        else _memoryCache.Set(REGISTER_CACHE_KEY + dto.PhoneNumber, dto,
            TimeSpan.FromMinutes(CACHED_FOR_MINUTS_REGISTER));

        return (Result: true, CachedMinutes: CACHED_FOR_MINUTS_REGISTER);
    }
    
    public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phoneNumber)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + phoneNumber, out RegisterDto registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();

            // make confirm code as random
            verificationDto.Code = CodeGenerator.GenerateRandomNumber();

            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + phoneNumber, out VerificationDto oldVerifcationDto))
            {
                _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + phoneNumber);
            }

            _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + phoneNumber, verificationDto,
                TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VERIFICATION));
            try
            {
                SmsSenderDto smsSenderDto =new SmsSenderDto();
                smsSenderDto.Title = "Book Home\n";
                smsSenderDto.Content = "Your verification code : " + verificationDto.Code;
                smsSenderDto.Recipent = phoneNumber.Substring(1);


                var smsResult = await _smsSender.SendAsync(smsSenderDto);
                if (smsResult is true) return (Result: true, CachedVerificationMinutes: CACHED_FOR_MINUTS_VERIFICATION);
                else return (Result: false, CachedVerificationMinutes: 0);

            }
            catch
            {
                return (Result: false, CachedVerificationMinutes: 0);
            }
   
        }
        else throw new UserCacheDataExpiredException();
    }
    
    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string phoneNumber, int code)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + phoneNumber, out RegisterDto registerDto))
        {
            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + phoneNumber, out VerificationDto verificationDto))
            {
                if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                    throw new VerificationTooManyRequestsException();
                else if (verificationDto.Code == code)
                {
                    var dbResult = await RegisterToDatabaseAsync(registerDto);
                    if (dbResult is true)
                    {
                        var user = await _userRepository.GetByPhoneAsync(phoneNumber);
                        string token = _tokenService.GenerateToken(user);
                        return (Result: true, Token: token);
                    }
                    else return (Result: false, Token: "");
                }
                else
                {
                    _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + phoneNumber);
                    verificationDto.Attempt++;
                    _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + phoneNumber, verificationDto,
                        TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VERIFICATION));
                    return (Result: false, Token: "");
                }
            }
            else throw new VerificationCodeExpiredException();
        }
        else throw new UserCacheDataExpiredException();
    }
    
    private async Task<bool> RegisterToDatabaseAsync(RegisterDto registerDto)
    {
        User user = new User()
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            PhoneNumber = registerDto.PhoneNumber,
            PhoneNumberConfirme = true,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };

        var hasherResult = PasswordHasher.Hash(registerDto.Password);
        user.PasswordHash = hasherResult.Hash;
        user.Salt = hasherResult.Salt;

        user.CreatedAt = user.UpdatedAt = user.LastActivity = TimeHelper.GetDateTime();
        user.IdentityRole = IdentityRole.User;

        var dbResult = await _userRepository.CreateAsync(user);
        return dbResult > 0;
    }
   
    public async Task<(bool Result, string Token)> LoginAsync(LoginDto dto)
    {

        var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
        if (user is null) throw new UserNotFoundException();

        var hasherResult = PasswordHasher.Verify(dto.Password, user.PasswordHash, user.Salt);
        if (hasherResult == false) throw new PasswordNotMatchException();

        string token = _tokenService.GenerateToken(user);
        return (Result: true, Token: token);
    }
    
    public async Task<(bool Result, int CachedMinutes)> ResetPasswordAsync(ResetPasswordDto dto)
    {
        var dbResult = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);

        if (dbResult is null)
            throw new UserNotFoundException();

        RegisterDto registerDto = new RegisterDto()
        {
            FirstName = dbResult.FirstName,
            LastName = dbResult.LastName,
            PhoneNumber = dto.PhoneNumber,
            Password = dto.NewPassword,
        };

        if (_memoryCache.TryGetValue(Reset_CACHE_KEY + dto.PhoneNumber, out RegisterDto dtoRegister))
        {
            dtoRegister.PhoneNumber = dtoRegister.PhoneNumber;
            _memoryCache.Remove(dto.PhoneNumber);
        }
        else
        {
            _memoryCache.Set(Reset_CACHE_KEY + dto.PhoneNumber, registerDto, TimeSpan.FromMinutes
                (CACHED_FOR_MINUTS_VERIFICATION));
        }

        if (_memoryCache.TryGetValue(Reset_CACHE_KEY + dto.PhoneNumber, out RegisterDto registerD))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();
            verificationDto.Code = CodeGenerator.GenerateRandomNumber();
            _memoryCache.Set(dto.PhoneNumber, verificationDto, TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VERIFICATION));

            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + dto.PhoneNumber,
                out VerificationDto OldverificationDto))
            {
                _memoryCache.Remove(dto.PhoneNumber);
            }

            _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + dto.PhoneNumber, verificationDto,
                TimeSpan.FromMinutes(VERIFICATION_MAXIMUM_ATTEMPTS));

            SmsSenderDto smsSenderDto = new SmsSenderDto();
            smsSenderDto.Title = "Book home\n";
            smsSenderDto.Content = "Your verification code : " + verificationDto.Code;
            smsSenderDto.Recipent = dto.PhoneNumber.Substring(1);
            var result = await _smsSender.SendAsync(smsSenderDto);

            if (result is true)
                return (Result: true, CachedVerificationMinutes: CACHED_FOR_MINUTS_VERIFICATION);
            else
                return (Result: false, CachedVerificationMinutes : 0);
        }
        else
        {
            throw new ExpiredException();
        }
    }
    
    public async Task<bool> CheckTokenAsync(AuthorizationDto token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(token.Authorization, validationParameters, out validatedToken);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<(bool Result, string Token)> VerifyResetPasswordAsync(string phoneNumber, int code)
    {
        if (_memoryCache.TryGetValue(Reset_CACHE_KEY + phoneNumber, out RegisterDto userRegisterDto))
        {
            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + phoneNumber, out VerificationDto verificationDto))
            {
                if (verificationDto.Code == code)
                {
                    var dbcheck = await _userRepository.GetByPhoneAsync(phoneNumber);
                    var dbresult = await ResetAsync(dbcheck.Id, userRegisterDto);
                    if (dbresult > 0)
                    {
                        var result = await _userRepository.GetByPhoneAsync(phoneNumber);
                        User user = new User()
                        {
                            Id = dbcheck.Id,
                            FirstName = result.FirstName,
                            LastName = result.LastName,
                            PhoneNumber = result.PhoneNumber,
                            PhoneNumberConfirme = result.PhoneNumberConfirme,
                            PassportSeriaNumber = result.PassportSeriaNumber,
                            Country = result.Country,
                            BirthDate = result.BirthDate,
                            LastActivity = result.LastActivity,
                            IsMale = result.IsMale,
                            Region = result.Region,
                            District = result.District,
                            Address = result.Address,
                            IdentityRole = IdentityRole.User,
                            CreatedAt = result.CreatedAt,
                            UpdatedAt = result.UpdatedAt,
                        };

                        string token = _tokenService.GenerateToken(user);

                        return (Result: true, Token: token);
                    }
                    else
                        return (Result: false, Token: "");
                }
                else
                {
                    _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + phoneNumber);
                    verificationDto.Attempt++;
                    _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + phoneNumber, verificationDto,
                        TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VERIFICATION));

                    return (Result: false, Token: "");
                }
            }
            else throw new VerificationCodeExpiredException();
        }
        else throw new ExpiredException();
    }

    private async Task<int> ResetAsync(long id, RegisterDto userRegisterDto)
    {
        User user = new User()
        {
            FirstName = userRegisterDto.FirstName,
            LastName = userRegisterDto.LastName,
            PhoneNumber = userRegisterDto.PhoneNumber,
            PhoneNumberConfirme = true,
            UpdatedAt = TimeHelper.GetDateTime(),
        };

        var hasher = PasswordHasher.Hash(userRegisterDto.Password);
        user.PasswordHash = hasher.Hash;
        user.Salt = hasher.Salt;
        var dbResult = await _userRepository.UpdateAsync(id, user);

        return dbResult;
    }

    private static TokenValidationParameters GetValidationParameters()
    {
        return new TokenValidationParameters()
        {
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidIssuer = "http://BookHome.uz",
            ValidAudience = "BookHome",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("23f926fb-dcd2-49f4-8fe2-992aac18f08f")) // The same key as the one that generate the token
        };
    }

}
