using Bookhome.DataAcces.Common.Interfaces;
using BookHome.Domain.Entities.Authors;
using BookHome.Domain.Entities.Books;

namespace Bookhome.DataAcces.Interfaces.Books;

public interface IBookImageRepository : IRepository<BookImage, BookImage>,
    IGetAll<BookImage>
{
    public Task<List<BookImage>> GetByIdAllAsync(long Id);
    public Task<List<BookImage>> GetFirstAllAsync();
}
