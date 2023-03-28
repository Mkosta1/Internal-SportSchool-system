using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class TrainingRepository
    : EfBaseRepository<Training, ApplicationDbContext>, ITrainingRepository
{
    public TrainingRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<Training>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.Id)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public override async Task<Training?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}