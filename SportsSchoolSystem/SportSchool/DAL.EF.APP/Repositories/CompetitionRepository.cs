using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class CompetitionRepository
    : EfBaseRepository<Competition, ApplicationDbContext>, ICompetitionRepository
{

    public CompetitionRepository(ApplicationDbContext dataContext) : base(dataContext)
    {

    }

    public override async Task<IEnumerable<Competition>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.AppUser)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public override async Task<Competition?> FindAsync(Guid id)
    { 
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<Competition>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(e => e.AppUser)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }
} 