using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface ILocationRepository : IBaseRepository<Location>
{
    public Task<IEnumerable<Location>> AllAsync(Guid userId);
    public Task<Location?> FindAsync(Guid id, Guid userId);
}