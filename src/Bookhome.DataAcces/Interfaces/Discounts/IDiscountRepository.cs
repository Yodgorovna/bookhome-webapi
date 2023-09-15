using Bookhome.DataAcces.Common.Interfaces;
using BookHome.Domain.Entities.Discounts;

namespace Bookhome.DataAcces.Interfaces.Discounts;

public interface IDiscountRepository : IRepository<Discount, Discount>,
    IGetAll<Discount>
{
}
