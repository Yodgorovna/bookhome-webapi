using Bookhome.Application.Utils;
using BookHome.Domain.Entities.Categories;
using BookHome.Persistance.Dtos.Categories;

namespace Bookhome.Services.Interfaces.Categories;

public interface ICategoryService
{ 
    public Task<bool> CreateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<long> CountAsync();

    public Task<IList<Category>> GetAllAsync(PaginationParams @params);

    public Task<Category> GetByIdAsync(long categoryId);

    public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto);
}
