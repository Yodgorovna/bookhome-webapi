using Bookhome.Application.Exceptions.Discounts;
using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Discounts;
using Bookhome.Services.Helpers;
using Bookhome.Services.Interfaces.Common;
using Bookhome.Services.Interfaces.Discounts;
using BookHome.Domain.Entities.Discounts;
using BookHome.Persistance.Dtos.Discounts;

namespace Bookhome.Services.Services.Discounts;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _repository;
    private readonly IPaginator _paginator;

    public DiscountService(IDiscountRepository discountRepository,
        IPaginator paginator)
    {
        this._repository = discountRepository;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(DiscountCreateDto dto)
    {
        Discount discount = new Discount()
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };

    var result = await _repository.CreateAsync(discount);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long discountId)
    {
        var discount = await _repository.GetByIdAsync(discountId);
        if (discount is null) throw new DiscountNotFoundException();

        var result = await _repository.DeleteAsync(discountId);
        return result > 0;
    }

    public async Task<IList<Discount>> GetAllAsync(PaginationParams @params)
    {
        var discounts = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return discounts;
    }

    public async Task<Discount> GetByIdAsync(long discountId)
    {
        var discount = await _repository.GetByIdAsync(discountId);
        if (discount is null) throw new DiscountNotFoundException();
        return discount;
    }

    public async Task<bool> UpdateAsync(long discountId, DiscountUpdateDto dto)
    {
        var discount = await _repository.GetByIdAsync(discountId);
        if (discount is null) throw new DiscountNotFoundException();

        discount.Name = dto.Name;
        discount.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.UpdateAsync(discountId, discount);
        return result > 0;
    }
}
