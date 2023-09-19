using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IUserAtTrainingRepository : IBaseRepository<UserAtTraining>, IUserAtTrainingRepositoryCustom<UserAtTraining>
{
    
}

public interface IUserAtTrainingRepositoryCustom<TEntity>
{
    public Task<IEnumerable<TEntity>> AllAsync(Guid userId);
    public Task<TEntity?> FindAsync(Guid id, Guid userId);

    Task<TEntity?> RemoveAsync(Guid id, Guid userId);
    
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
}
