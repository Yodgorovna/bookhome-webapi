using Bookhome.Application.Utils;
using BookHome.Domain.Entities.Orders;
using BookHome.Persistance.Dtos.Orders;
using BookHome.Persistance.Dtos.Users;

namespace Bookhome.Services.Interfaces.Users;

public interface IUserService
{
    public Task<bool> CreateAsync(UserCreateDto dto);

    public Task<bool> DeleteAsync(long orderId);

    public Task<long> CountAsync();

    public Task<IList<Order>> GetAllAsync(PaginationParams @params);

    public Task<Order> GetByIdAsync(long orderId);

    public Task<bool> UpdateAsync(long orderId, OrderUpdateDto dto);
}
