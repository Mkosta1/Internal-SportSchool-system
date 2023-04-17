using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class ExcerciseRepository 
    : EFBaseRepository<Excercise, ApplicationDbContext>, IExerciseRepository
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
}