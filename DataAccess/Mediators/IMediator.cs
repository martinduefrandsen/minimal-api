using DataAccess.Models;

namespace DataAccess.Mediators;

public interface IMediator
{
    Task<IEnumerable<Pet>> GetAll();
}