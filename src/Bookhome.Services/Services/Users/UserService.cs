using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Users;
using BookHome.Domain.Entities.Orders;
using BookHome.Domain.Entities.Users;
using BookHome.Persistance.Dtos.Orders;
using BookHome.Persistance.Dtos.Users;

namespace Bookhome.Services.Services.Users;

public class UserService : IUserService
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public  Task<bool> CreateAsync(UserCreateDto dto)
    {
        //User user = new User()
        //{
        //    FirstName = dto.FirstName,
        //    LastName = dto.LastName,
        //    PhoneNumber = dto.PhoneNumber,
        //    PassportSeriaNumber = dto.PassportSeriaNumber,
        //    IsMale = dto.IsMale,
        //    BirthDate = dto.BirthDate,
        //    Country = dto.Country,
        //    Region = dto.Region,
        //    District = dto.District,
        //    Address = dto.Address,




        //};
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long orderId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Order>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByIdAsync(long orderId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long orderId, OrderUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
