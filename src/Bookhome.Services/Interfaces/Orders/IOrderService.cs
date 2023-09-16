using Bookhome.Application.Utils;
using BookHome.Domain.Entities.Orders;
using BookHome.Persistance.Dtos.Orders;

namespace Bookhome.Services.Interfaces.Orders;

public interface IOrderService
{
    public Task<bool> CreateAsync(OrderCreateDto dto);

    public Task<bool> DeleteAsync(long orderId);

    public Task<long> CountAsync();

    public Task<IList<Order>> GetAllAsync(PaginationParams @params);

    public Task<Order> GetByIdAsync(long orderId);

    public Task<bool> UpdateAsync(long orderId, OrderUpdateDto dto);
}
