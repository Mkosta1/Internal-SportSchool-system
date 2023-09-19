using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class UserAtCompetitionRepository
    : EFBaseRepository<UserAtCompetition, ApplicationDbContext>, IUserAtCompetitionRepository
{
    public UserAtCompetitionRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<UserAtCompetition>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.AppUser)
            .OrderBy(e => e.Since)
            .ToListAsync();
    }

    public  override async Task<UserAtCompetition?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<UserAtCompetition>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .OrderBy(e => e.AppUser)
            .ToListAsync();
    }

    public virtual async Task<UserAtCompetition?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<UserAtCompetition?> RemoveAsync(Guid id, Guid userId)
    {
        var UserAtCompetition = await FindAsync(id, userId);
        return UserAtCompetition == null ? null : Remove(UserAtCompetition);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet.AnyAsync(t => t.Id == id && t.Id == userId);
    }

}