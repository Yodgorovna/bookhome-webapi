using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Users;
using Bookhome.DataAcces.ViewModels.Users;
using BookHome.Domain.Entities.Users;
using Dapper;

namespace Bookhome.DataAcces.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from users";
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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.users(" +
                "first_name, last_name, phone_number, passport_seria_number, " +
                "is_male, birth_date, country, region, district, address, " +
                "password_hash, salt, image_path, last_activity, identity_role, " +
                "created_at, updated_at, phone_number_confirme) " +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @PassportSeriaNumber, " +
                "@IsMale, @BirthDate, @Country, @Region, @District, @Address, " +
                "@PasswordHash, @Salt, @ImagePath, @LastActivity, @IdentityRole, " +
                "@CreatedAt, @UpdatedAt, @PhoneNumberConfirme);";

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
            string query = "DELETE FROM public.users WHERE id = @Id;";
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

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM public.users order by id desc " +
                $"offset {@params.GetSkipCount} limit {@params.PageSize};";

            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }

    }

    public async Task<UserViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.users WHERE id = @Id;";
            var result = await _connection.QuerySingleAsync(query, new { Id = id });
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

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM public.users WHERE phone_number = @PhoneNumber; ";

            var result = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
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

    public async Task<(int ItemsCount, IList<UserViewModel>)> SearchAsync(string search)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $" SELECT *  FROM users WHERE title ILIKE '%{search}%'order by id desc ";

            var result = await _connection.QueryAsync<UserViewModel>(query);
            int Count = result.Count();

            return (Count, result.ToList());
        }
        catch
        {
            return (0, new List<UserViewModel>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.users " +
                $"SET first_name=@Firstname, last_name=@LastName, phone_number=@PhoneNuber, " +
                $"passport_seria_number=@PassportSeriaNumber, is_male=@IsMale, birth_date=@BirthDate, " +
                $"country=@Country, region=@Region, district=@Dictrict, address=@Address, " +
                $"image_path=@ImagePath, last_activity=@LastActivity, identity_role=@IdentityRole, " +
                $"created_at=@CreatedAt, updated_at=UpdatedAt, phone_number_confirme = @PhoneNumberConfirme" +
                $"WHERE Id = {id};";

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
