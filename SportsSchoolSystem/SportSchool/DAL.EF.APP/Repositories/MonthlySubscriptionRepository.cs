using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class MonthlySubscriptionRepository
    : EFBaseRepository<MonthlySubscription, ApplicationDbContext>, IMonthlySubscriptionRepository
{
    public MonthlySubscriptionRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<MonthlySubscription>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.AppUsers)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public override async Task<MonthlySubscription?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<MonthlySubscription>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(e => e.AppUsers)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public virtual async Task<MonthlySubscription?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(t => t.AppUsers)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<MonthlySubscription?> RemoveAsync(Guid id, Guid userId)
    {
        var monthlySubscription = await FindAsync(id, userId);
        return monthlySubscription == null ? null : Remove(monthlySubscription);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet.AnyAsync(t => t.Id == id && t.Id == userId);
    }
}