using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class UserInGroupRepository
    : EfBaseRepository<UserInGroup, ApplicationDbContext>, IUserInGroupRepository
{
    public UserInGroupRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<UserInGroup>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.AppUser)
            .OrderBy(e => e.Since)
            .ToListAsync();
    }

    public override async Task<UserInGroup?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}