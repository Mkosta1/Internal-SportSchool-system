using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class MonthlySubscriptionRepository
    : EfBaseRepository<MonthlySubscription, ApplicationDbContext>, IMonthlySubscriptionRepository
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
}