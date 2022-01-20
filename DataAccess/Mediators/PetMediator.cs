using DataAccess.Models;
using DataAccess.Providers;

namespace DataAccess.Mediators;

public class PetMediator : IMediator
{
    private readonly IRelationalDatabaseProvider _database;

    public PetMediator(IRelationalDatabaseProvider database)
    {
        _database = database;
    }

    public Task<IEnumerable<Pet>> GetAll() => _database.LoadData<Pet, dynamic>("sp_Pet_GetAll", new {});
}