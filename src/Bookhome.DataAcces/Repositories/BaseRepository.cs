using Npgsql;

namespace Bookhome.DataAcces.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        this._connection = new NpgsqlConnection(
            "Host = localhost; " +
            "Port = 5432 " +
            "Database = book-shop-db " +
            "Password = 0409; ");   
    }
}
