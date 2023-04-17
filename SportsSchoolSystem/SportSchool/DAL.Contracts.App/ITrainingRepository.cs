using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface ITrainingRepository : IBaseRepository<Training>
{
    public Task<IEnumerable<Training>> AllAsync(Guid userId);
    public Task<Training?> FindAsync(Guid id, Guid userId);
}