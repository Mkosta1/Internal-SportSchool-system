using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class LocationRepository
    : EfBaseRepository<Location, ApplicationDbContext>, ILocationRepository
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
}