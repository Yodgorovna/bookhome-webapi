using Bookhome.Application.Utils;
using Bookhome.DataAcces.Common.Interfaces;
using Bookhome.DataAcces.Interfaces.Books;
using Bookhome.DataAcces.ViewModels.Books;
using BookHome.Domain.Entities.Authors;
using BookHome.Domain.Entities.Books;
using Dapper;

namespace Bookhome.DataAcces.Repositories.Books;

public class BookRepository : BaseRepository, IBookRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from books";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Book entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.books( " +
                "category_id, name, description, price, ishard_cover, created_at, updated_at)" +
                "VALUES (@CategoryId, @Name, @Description, @Price, " +
                "@IsHardCover, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }

    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM public.books WHERE id = @Id;";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<BookViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM public.books order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize};";

            var result = (await _connection.QueryAsync<BookViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<BookViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<BookViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.books WHERE id = @Id;";
            var result = await _connection.QuerySingleAsync<BookViewModel>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync(); 
        }
    }

    public async Task<(int ItemsCount, IList<BookViewModel>)> SearchAsync(string search)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $" SELECT *  FROM books WHERE title ILIKE '%{search}%'order by id desc ";


            var result = await _connection.QueryAsync<BookViewModel>(query);
            int Count = result.Count();

            return (Count, result.ToList());
        }
        catch
        {
            return (0, new List<BookViewModel>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Book entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query =$"UPDATE public.books " +
                $"SET category_id=@CategoryId, name=@Name, description=@Description, " +
                $"price=@Price, ishard_cover=@IsHardCover, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id = {id};";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

}
