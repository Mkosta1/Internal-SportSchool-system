using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class SportSchoolRepository
    : EFBaseRepository<SportsSchool, ApplicationDbContext>, ISportSchoolRepository
{
    public SportSchoolRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<SportsSchool>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.AppUser)
            .OrderBy(e => e.Address)
            .ToListAsync();
    }

    public override async Task<SportsSchool?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<SportsSchool>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(e => e.AppUser)
            .OrderBy(e => e.Address)
            .ToListAsync();
    }

    public virtual async Task<SportsSchool?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(t => t.AppUser)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<SportsSchool?> RemoveAsync(Guid id, Guid userId)
    {
        var sportsSchool = await FindAsync(id, userId);
        return sportsSchool == null ? null : Remove(sportsSchool);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet.AnyAsync(t => t.Id == id && t.Id == userId);
    }
}