using Bookhome.DataAcces.Common.Interfaces;
using Bookhome.DataAcces.ViewModels.Books;
using BookHome.Domain.Entities.Books;

namespace Bookhome.DataAcces.Interfaces.Books;

public interface IBookRepository : IRepository<Book, BookViewModel>,
    IGetAll<BookViewModel>, ISearchable<BookViewModel>
{
}
