using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Authors;
using BookHome.Domain.Entities.Authors;
using BookHome.Domain.Entities.Categories;
using Dapper;

namespace Bookhome.DataAcces.Repositories.Authors;

public class AuthorRepository : BaseRepository, IAuthorRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from authors";   
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

    public async Task<int> CreateAsync(Author entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.authors( " +
                "first_name, last_name, country, created_at, updated_at) " +
                "VALUES (@FirstName, @LastName, @Country, @CreatedAt, @UpdatedAt); ";
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
            string query = "DELETE FROM public.authors WHERE id = @Id;";
            var result = await _connection.ExecuteAsync(query, new {Id = id});
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

    public async Task<IList<Author>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM public.authors order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize};";

            var result = (await _connection.QueryAsync<Author>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Author>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Author?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.authors WHERE id = @Id;";
            var result = await _connection.QuerySingleAsync<Author>(query, new { Id = id });
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

    public async Task<(int ItemsCount, IList<Author>)> SearchAsync(string search)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $" SELECT *  FROM authors WHERE title ILIKE '%{search}%'order by id desc ";


            var result = await _connection.QueryAsync<Author>(query);
            int Count = result.Count();

            return (Count, result.ToList());
        }
        catch
        {
            return (0, new List<Author>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Author entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.authors " +
                $"SET first_name=@Firstname, last_name=@LastName, country=@Country, " +
                $"created_at=@CreatedAt, updated_at=@UpdatedAt " +
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
