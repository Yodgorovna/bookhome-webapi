using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Orders;
using Bookhome.DataAcces.ViewModels.Orders;
using BookHome.Domain.Entities.Orders;
using Dapper;

namespace Bookhome.DataAcces.Repositories.Orders;

public class OrderRepository :BaseRepository, IOrderRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM orders";
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

    public async Task<int> CreateAsync(Order entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.orders( users_id, status, books_price, " +
                "delivery_price, result_price, latitude, longitude, payment_type, is_paid, " +
                "is_contracted, description, created_at, updated_at) " +
                "VALUES(@UserId, @UserId, @BookPrice, @DeliveryPrice, @ResultPrice, " +
                "@Latitude, @Longitude, @PaymentType, @IsPaid, @IsContracted, " +
                "@Description, @CreatedAt, @UpdatedAt); ";

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
            string query = "DELETE FROM public.orders WHERE id = @Id;";
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

    public async Task<IList<OrderViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM public.orders order by id desc " +
                $"offset {@params.GetSkipCount} limit {@params.PageSize};";

            var result = (await _connection.QueryAsync<OrderViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<OrderViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<OrderViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.orders WHERE id = @Id;";
            var result = await _connection.QuerySingleAsync<OrderViewModel>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Order entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.authors " +
                $"SET users_id=@UserId, status=@Status, books_price=@BooksPrice, " +
                $"delivery_price=@DeliveryPrice, result_price=@ResultPrice, " +
                $"latitude=@Latitude, longitude=@Longitude, payment_type=@PaymentType, " +
                $"is_paid=@IsPaid, is_contracted=IsContracted, description=@Description, " +
                $"created_at=@CreatedAt, updated_at=@UpdatedAt " +
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
