using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class UserTypeRepository
    : EfBaseRepository<UserType, ApplicationDbContext>, IUserTypeRepository
{
    public UserTypeRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<UserType>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.AppUsers)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public override async Task<UserType?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}