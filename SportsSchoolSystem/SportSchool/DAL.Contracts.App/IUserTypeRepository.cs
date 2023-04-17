using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IUserTypeRepository : IBaseRepository<UserType>
{
    public Task<IEnumerable<UserType>> AllAsync(Guid userId);
    public Task<UserType?> FindAsync(Guid id, Guid userId);
}