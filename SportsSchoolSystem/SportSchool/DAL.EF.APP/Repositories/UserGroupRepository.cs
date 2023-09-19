using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class UserGroupRepository
    : EFBaseRepository<UserGroup, ApplicationDbContext>, IUserGroupRepository
{
    public UserGroupRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<UserGroup>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.UserInGroup)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public override async Task<UserGroup?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<UserGroup>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(e => e.UserInGroup)!
            .ThenInclude(t => t.AppUser)
            .OrderBy(t => t.Name)
            .ToListAsync();
    }

    public virtual async Task<UserGroup?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(t => t.UserInGroup)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<UserGroup?> RemoveAsync(Guid id, Guid userId)
    {
        var userGroup = await FindAsync(id, userId);
        return userGroup == null ? null : Remove(userGroup);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet.AnyAsync(t => t.Id == id && t.Id == userId);
    }
}
