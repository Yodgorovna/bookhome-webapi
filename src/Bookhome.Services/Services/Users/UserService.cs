using Bookhome.Application.Exceptions.Auth;
using Bookhome.Application.Exceptions.Users;
using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Users;
using Bookhome.DataAcces.ViewModels.Users;
using Bookhome.Services.Helpers;
using Bookhome.Services.Interfaces.Auth;
using Bookhome.Services.Interfaces.Common;
using Bookhome.Services.Interfaces.Users;
using Bookhome.Services.Security;
using BookHome.Domain.Entities.Users;
using BookHome.Persistance.Dtos.Users;

namespace Bookhome.Services.Services.Users;

public class UserService : IUserService
{
    private readonly IFileService _fileservice;
    private readonly IIdentityService _identity;
    private readonly IPaginator _paginator;
    private readonly IUserRepository _repository;
    private readonly string USERIMAGES = "UserImages";

    public UserService(
        IUserRepository userRepository,
        IPaginator paginator,
        IIdentityService identity,
        IFileService fileService)
    {
        this._fileservice = fileService;
        this._identity = identity;
        this._paginator = paginator;
        this._repository = userRepository;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync(); 

    public async Task<bool> CreateAsync(UserCreateDto dto)
    {
        User user = new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            PassportSeriaNumber = dto.PassportSeriaNumber,
            IsMale = dto.IsMale,
            PhoneNumberConfirme = dto.PhoneNumberConfirme,
            BirthDate = dto.BirthDate,
            LastActivity = dto.LastActivity,
            Country = dto.Country,
            Region = dto.Region,
            District = dto.District,
            Address = dto.Address,
            PasswordHash = dto.Password,
            ImagePath = dto.ImagePath,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var DbResult = await _repository.CreateAsync(user);
        return DbResult > 0;
    }

    public async Task<bool> DeleteAsync(long userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFoundException();

        var result = await _repository.DeleteAsync(userId);
        return result > 0;
    }

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return result;
    }

    public async Task<UserViewModel> GetByIdAsync(long userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFoundException();
        return user;
    }

    public Task<(long IteamCount, List<UserViewModel>)> SearchAsync(string search)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(UserUpdateDto dto)
    {
        var user = await _repository.GetByPhoneAsync(_identity.PhoneNumber);
        if (user is null) throw new UserNotFoundException();

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;
        user.PhoneNumberConfirme = dto.PhoneNumberConfirme;
        user.PassportSeriaNumber = dto.PassportSeriaNumber;
        user.IsMale = dto.IsMale;
        user.BirthDate = dto.BirthDate;
        user.Country = dto.Country;
        user.Region = dto.Region;
        user.District = dto.District;
        user.Address = dto.Address;
        user.ImagePath = dto.ImagePath;
        user.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.UpdateAsync(_identity.UserId, user);
        return result > 0;
    }

    public async Task<bool> UpdateSecuryAsync(UserSecurityUpdate dto)
    {
        var user = await _repository.GetByPhoneAsync(_identity.PhoneNumber);
        if (user is null) throw new UserNotFoundException();


        var hasherResult = PasswordHasher.Verify(dto.OldPassword, user.Salt, user.PasswordHash);
        if (hasherResult == false) throw new PasswordNotMatchException();

        if (dto.NewPassword == dto.ReturnNewPassword)
        {
            var hasher = PasswordHasher.Hash(dto.NewPassword);
            user.PasswordHash = hasher.Hash;
            user.Salt = hasher.Salt;

            var res = await _repository.UpdateAsync(_identity.UserId, user);

            return res > 0;
        }

        return false;
    }
}
