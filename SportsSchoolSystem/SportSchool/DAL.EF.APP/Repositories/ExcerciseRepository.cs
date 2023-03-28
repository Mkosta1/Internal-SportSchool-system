using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class ExcerciseRepository 
    : EfBaseRepository<Excercise, ApplicationDbContext>, IExerciseRepository
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
}