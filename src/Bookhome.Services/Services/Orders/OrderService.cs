using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Orders;
using BookHome.Domain.Entities.Orders;
using BookHome.Persistance.Dtos.Orders;

namespace Bookhome.Services.Services.Orders;

public class OrderService : IOrderService
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(OrderCreateDto dto)
    {
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
