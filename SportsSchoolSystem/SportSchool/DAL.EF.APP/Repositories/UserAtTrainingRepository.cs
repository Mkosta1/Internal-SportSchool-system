using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class UserAtTrainingRepository
    : EfBaseRepository<UserAtTraining, ApplicationDbContext>, IUserAtTrainingRepository
{
    public UserAtTrainingRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<UserAtTraining>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.AppUser)
            .OrderBy(e => e.Since)
            .ToListAsync();
    }

    public override async Task<UserAtTraining?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}