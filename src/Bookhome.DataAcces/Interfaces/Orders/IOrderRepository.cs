using Bookhome.DataAcces.Common.Interfaces;
using Bookhome.DataAcces.ViewModels.Orders;
using BookHome.Domain.Entities.Orders;

namespace Bookhome.DataAcces.Interfaces.Orders;

public interface IOrderRepository : IRepository<Order, OrderViewModel>,
    IGetAll<OrderViewModel>
{
}
