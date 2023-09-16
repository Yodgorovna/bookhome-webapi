using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Categories;
using Bookhome.Services.Helpers;
using Bookhome.Services.Interfaces.Categories;
using BookHome.Domain.Entities.Categories;
using BookHome.Persistance.Dtos.Categories;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;

namespace Bookhome.Services.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._repository = categoryRepository;   
        }
        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

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

        public Task<bool> DeleteAsync(long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Category>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
