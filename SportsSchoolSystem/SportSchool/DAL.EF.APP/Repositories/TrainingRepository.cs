using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class TrainingRepository
    : EFBaseRepository<Training, ApplicationDbContext>, ITrainingRepository
{
    public TrainingRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<Training>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.UserAtTrainings)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public  override async Task<Training?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<Training>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public virtual async Task<Training?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}