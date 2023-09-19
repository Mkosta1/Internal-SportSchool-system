using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface ITrainingRepository : IBaseRepository<Training>, ITrainingRepositoryCustom<Training>
{
    
}

public interface ITrainingRepositoryCustom<TEntity>
{
    public Task<IEnumerable<TEntity>> AllAsync(Guid userId);
    public Task<TEntity?> FindAsync(Guid id, Guid userId);

    Task<TEntity?> RemoveAsync(Guid id, Guid userId);
    
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
}