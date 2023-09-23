using Bookhome.Application.Utils;
using Bookhome.DataAcces.ViewModels.Books;
using BookHome.Domain.Entities.Books;
using BookHome.Persistance.Dtos.Books;

namespace Bookhome.Services.Interfaces.Books;

public interface IBookService
{
    public Task<bool> CreateAsync(BookCreateDto dto);

    public Task<bool> DeleteAsync(long bookId);

    public Task<long> CountAsync();

    public Task<IList<BookViewModel>> GetAllAsync(PaginationParams @params);

    public Task<BookViewModel> GetByIdAsync(long bookId);

    public Task<bool> UpdateAsync(long bookId, BookUpdateDto dto);

    public Task<(long IteamCount, List<BookViewModel>)> SearchAsync(string search);
}
