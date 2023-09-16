using Bookhome.DataAcces.Handlers;
using Dapper;
using Npgsql;

namespace Bookhome.DataAcces.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection(
            "Host = localhost; " +
            "Port = 5432; " +
            "Database = book-shop-db; " +
            "User Id = postgres; " +
            "Password = 0409; ");   
    }
}
