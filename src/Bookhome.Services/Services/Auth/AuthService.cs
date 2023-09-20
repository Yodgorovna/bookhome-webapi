using Bookhome.Application.Exceptions.Users;
using Bookhome.DataAcces.Interfaces.Users;
using Bookhome.Services.Interfaces.Auth;
using BookHome.Persistance.Dtos.Auth;
using Microsoft.Extensions.Caching.Memory;

namespace Bookhome.Services.Services.Auth;
public class AuthService : IAuthService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepository _userRepository;

    public AuthService(IMemoryCache memoryCache, IUserRepository userRepository) 
    {
        this._memoryCache = memoryCache;
        this._userRepository = userRepository;
    }    
    public  Task<(bool Result, int CashedHours)> RegisterAsync(RegisterDto dto)
    {
        //var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
        //if (user is not null) throw new UserAlreadyExistsExseption(dto.PhoneNumber);

        //if(_memoryCache)
        throw new NotImplementedException();
    }

    public Task<(bool Result, int CashedVerificationHours)> SendCodeForRegistrationAsync(string phone)
    {
        throw new NotImplementedException();
    }

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code)
    {
        throw new NotImplementedException();
    }
}
