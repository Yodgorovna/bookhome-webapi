using Bookhome.Application.Utils;
using BookHome.Domain.Entities.Authors;
using BookHome.Persistance.Dtos.Authors;

namespace Bookhome.Services.Interfaces.Authors;

public interface IAuthorService
{
    public Task<bool> CreateAsync(AuthorCreateDto dto);

    public Task<bool> DeleteAsync(long authorId);

    public Task<long> CountAsync();

    public Task<IList<Author>> GetAllAsync(PaginationParams @params);

    public Task<Author> GetByIdAsync(long authorId);

    public Task<bool> UpdateAsync(long authorId, AuthorUpdateDto dto);
}
