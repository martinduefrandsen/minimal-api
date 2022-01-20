namespace DataAccess.Providers;

public interface IRelationalDatabaseProvider
{
    Task<IEnumerable<T>> LoadData<T, TU>(
        string storedProcedure,
        TU parameters,
        string connectionId = "Mysql");

    Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "Mysql");
}