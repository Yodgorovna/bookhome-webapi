using Bookhome.Application.Utils;
using BookHome.Domain.Entities.Discounts;
using BookHome.Persistance.Dtos.Discounts;

namespace Bookhome.Services.Interfaces.Discounts;

public interface IDiscountService
{
    public Task<bool> CreateAsync(DiscountCreateDto dto);

    public Task<bool> DeleteAsync(long discountId);

    public Task<long> CountAsync();

    public Task<IList<Discount>> GetAllAsync(PaginationParams @params);

    public Task<Discount> GetByIdAsync(long discountId);

    public Task<bool> UpdateAsync(long discountId, DiscountUpdateDto dto);
}
