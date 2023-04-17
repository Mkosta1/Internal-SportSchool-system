using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IUserAtTrainingRepository : IBaseRepository<UserAtTraining>
{
    public Task<IEnumerable<UserAtTraining>> AllAsync(Guid userId);
    public Task<UserAtTraining?> FindAsync(Guid id, Guid userId);
}