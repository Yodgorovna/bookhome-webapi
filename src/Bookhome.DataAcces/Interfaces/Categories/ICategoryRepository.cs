using Bookhome.DataAcces.Common.Interfaces;
using BookHome.Domain.Entities.Categories;

namespace Bookhome.DataAcces.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>,
    IGetAll<Category>
{

}
