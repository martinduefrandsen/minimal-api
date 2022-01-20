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
        string connectionId = "Default")
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));
        
        var sql = await File.ReadAllTextAsync(storedProcedure);
        
        return await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));

        var sql = await File.ReadAllTextAsync(storedProcedure);
        
        await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
    }
}