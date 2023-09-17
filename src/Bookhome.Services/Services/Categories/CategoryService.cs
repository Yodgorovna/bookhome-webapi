using Bookhome.Application.Exceptions.Categories;
using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Categories;
using Bookhome.Services.Helpers;
using Bookhome.Services.Interfaces.Categories;
using BookHome.Domain.Entities.Categories;
using BookHome.Persistance.Dtos.Categories;

namespace Bookhome.Services.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._repository = categoryRepository;   
        }
        public async Task<long> CountAsync() => await _repository.CountAsync();

        public async Task<bool> CreateAsync(CategoryCreateDto dto)
        {
            Category category = new Category()
            {
                Name = dto.Name,
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime()
            };

            var result = await _repository.CreateAsync(category);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(long categoryId)
        {
            var category = await _repository.GetByIdAsync(categoryId);
            if (category is null) throw new CategoryNotFoundException();

            var result = await _repository.DeleteAsync(categoryId);
            return result > 0;
        }

        public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
        {
            var categories = await _repository.GetAllAsync(@params);
            //var count = await _repository.CountAsync();
            return categories;
        }

        public async Task<Category> GetByIdAsync(long categoryId)
        {
            var category = await _repository.GetByIdAsync(categoryId);
            if (category is null) throw new CategoryNotFoundException();
            return category;
        }

        public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
        {
            var category = await _repository.GetByIdAsync(categoryId);
            if (category is null) throw new CategoryNotFoundException();

            category.Name = dto.Name;
            category.UpdatedAt = TimeHelper.GetDateTime();

            var result = await _repository.UpdateAsync(categoryId, category);
            return result > 0;
        }
    }
}
