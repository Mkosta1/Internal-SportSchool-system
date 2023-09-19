using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class ExcerciseRepository 
    : EFBaseRepository<Excercise, ApplicationDbContext>, IExcerciseRepository
{
    public ExcerciseRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<Excercise>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.Training)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public override async Task<Excercise?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<Excercise>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(e => e.Training)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public virtual async Task<Excercise?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(t => t.Training)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Excercise?> RemoveAsync(Guid id, Guid userId)
    {
        var excercise = await FindAsync(id, userId);
        return excercise == null ? null : Remove(excercise);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet.AnyAsync(t => t.Id == id && t.Id == userId);
    }
}