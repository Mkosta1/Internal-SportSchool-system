using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IMonthlySubscriptionRepository : IBaseRepository<MonthlySubscription>, IMonthlySubscriptionRepositoryCustom<MonthlySubscription>
{
    
}

public interface IMonthlySubscriptionRepositoryCustom<TEntity>
{
    public Task<IEnumerable<TEntity>> AllAsync(Guid userId);
    public Task<TEntity?> FindAsync(Guid id, Guid userId);

    Task<TEntity?> RemoveAsync(Guid id, Guid userId);
    
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
}