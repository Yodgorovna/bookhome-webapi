using Bookhome.DataAcces.Common.Interfaces;
using Bookhome.DataAcces.ViewModels.Users;
using BookHome.Domain.Entities.Users;

namespace Bookhome.DataAcces.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>,
    IGetAll<UserViewModel>, ISearchable<UserViewModel>  
{
    public Task<User?> GetByPhoneAsync(string phone);   
}
