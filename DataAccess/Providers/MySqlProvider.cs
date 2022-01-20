using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DataAccess.Providers;

public class MySqlProvider : IRelationalDatabaseProvider
{
    private readonly IConfiguration _config;

    public MySqlProvider(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, TU>(
        string storedProcedure,
        TU parameters,
        string connectionId = "Mysql")
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));
        
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "Mysql")
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}