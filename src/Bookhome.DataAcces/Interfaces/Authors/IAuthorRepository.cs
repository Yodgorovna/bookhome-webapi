using Bookhome.DataAcces.Common.Interfaces;
using BookHome.Domain.Entities.Authors;

namespace Bookhome.DataAcces.Interfaces.Authors;

public interface IAuthorRepository : IRepository<Author, Author>,
    IGetAll<Author>, ISearchable<Author>    
{
}
