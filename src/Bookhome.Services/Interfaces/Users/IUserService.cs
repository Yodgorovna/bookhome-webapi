using Bookhome.Application.Utils;
using Bookhome.DataAcces.ViewModels.Users;
using BookHome.Persistance.Dtos.Users;

namespace Bookhome.Services.Interfaces.Users;

public interface IUserService
{
    public Task<bool> DeleteAsync(long userId);
    public Task<bool> UpdateAsync(UserUpdateDto dto);
    public Task<bool> UpdateSecuryAsync(UserSecurityUpdate dto);
    public Task<long> CountAsync();
    public Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params);
    public Task<UserViewModel> GetByIdAsync(long userId);
    public Task<(long IteamCount, List<UserViewModel>)> SearchAsync(string search);
}
