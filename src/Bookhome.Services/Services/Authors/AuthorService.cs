using Bookhome.Application.Exceptions.Authors;
using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Authors;
using Bookhome.Services.Helpers;
using Bookhome.Services.Interfaces.Authors;
using Bookhome.Services.Interfaces.Common;
using BookHome.Domain.Entities.Authors;
using BookHome.Persistance.Dtos.Authors;

namespace Bookhome.Services.Services.Authors;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    private readonly IPaginator _paginator;

    public AuthorService(IAuthorRepository authorRepository, IPaginator paginator)
    {
        this._repository = authorRepository;    
        this._paginator = paginator;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(AuthorCreateDto dto)
    {
        Author author = new Author()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Country = dto.Country,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };

        var result = await _repository.CreateAsync(author);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long authorId)
    {
        var author = await _repository.GetByIdAsync(authorId);
        if (author is null) throw new AuthorNotFoundException();

        var result = await _repository.DeleteAsync(authorId);
        return result > 0;
    }

    public async Task<IList<Author>> GetAllAsync(PaginationParams @params)
    {
        var authors = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return authors;
    }

    public async Task<Author> GetByIdAsync(long authorId)
    {
        var author = await _repository.GetByIdAsync(authorId);
        if (author is null) throw new AuthorNotFoundException();
        return author;
    }

    public async Task<bool> UpdateAsync(long authorId, AuthorUpdateDto dto)
    {
        var author = await _repository.GetByIdAsync(authorId);
        if (author is null) throw new AuthorNotFoundException();

        author.FirstName = dto.FirstName;
        author.LastName = dto.LastName;
        author.Country = dto.Country;
        author.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.UpdateAsync(authorId, author);
        return result > 0;
    }

}
