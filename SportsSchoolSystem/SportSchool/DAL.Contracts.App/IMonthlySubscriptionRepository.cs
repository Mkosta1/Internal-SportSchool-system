using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IMonthlySubscriptionRepository : IBaseRepository<MonthlySubscription>
{
    public Task<IEnumerable<MonthlySubscription>> AllAsync(Guid userId);
    public Task<MonthlySubscription?> FindAsync(Guid id, Guid userId);
}