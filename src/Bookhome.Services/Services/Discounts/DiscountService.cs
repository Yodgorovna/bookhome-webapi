using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Discounts;
using BookHome.Domain.Entities.Discounts;
using BookHome.Persistance.Dtos.Discounts;

namespace Bookhome.Services.Services.Discounts;

public class DiscountService : IDiscountService
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(DiscountCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long discountId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Discount>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<Discount> GetByIdAsync(long discountId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long discountId, DiscountUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
