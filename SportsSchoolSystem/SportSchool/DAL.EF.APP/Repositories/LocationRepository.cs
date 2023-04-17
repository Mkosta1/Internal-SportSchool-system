using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class LocationRepository
    : EFBaseRepository<Location, ApplicationDbContext>, ILocationRepository
{
    public LocationRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<Location>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.Competition)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public override async Task<Location?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<Location>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public virtual async Task<Location?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(t => t.Competition)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}