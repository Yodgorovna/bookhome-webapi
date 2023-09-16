using Bookhome.Application.Utils;
using BookHome.Domain.Entities.Books;
using BookHome.Persistance.Dtos.Books;

namespace Bookhome.Services.Interfaces.Books;

public interface IBookService
{
    public Task<bool> CreateAsync(BookCreateDto dto);

    public Task<bool> DeleteAsync(long bookId);

    public Task<long> CountAsync();

    public Task<IList<Book>> GetAllAsync(PaginationParams @params);

    public Task<Book> GetByIdAsync(long bookId);

    public Task<bool> UpdateAsync(long bookId, BookUpdateDto dto);
}
