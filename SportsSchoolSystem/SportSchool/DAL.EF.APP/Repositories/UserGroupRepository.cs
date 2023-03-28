using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class UserGroupRepository
    : EfBaseRepository<UserGroup, ApplicationDbContext>, IUserGroupRepository
{
    public UserGroupRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<UserGroup>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.Id)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public override async Task<UserGroup?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}
