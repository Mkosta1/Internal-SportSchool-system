using DAL.Contracts.Base;
using DAL.EF.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IExcerciseRepository : IBaseRepository<Excercise>, IExcerciseRepositoryCustom<Excercise>
{

}

public interface IExcerciseRepositoryCustom<TEntity>
{
    public Task<IEnumerable<TEntity>> AllAsync(Guid userId);
    public Task<TEntity?> FindAsync(Guid id, Guid userId);
    
    Task<TEntity?> RemoveAsync(Guid id, Guid userId);
    
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
}