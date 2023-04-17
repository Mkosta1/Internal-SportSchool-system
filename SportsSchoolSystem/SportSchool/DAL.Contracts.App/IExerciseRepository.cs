using DAL.Contracts.Base;
using DAL.EF.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IExerciseRepository : IBaseRepository<Excercise>
{
    public Task<IEnumerable<Excercise>> AllAsync(Guid userId);
    public Task<Excercise?> FindAsync(Guid id, Guid userId);

}