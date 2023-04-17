using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IUserGroupRepository : IBaseRepository<UserGroup>
{
    public Task<IEnumerable<UserGroup>> AllAsync(Guid userId);
    public Task<UserGroup?> FindAsync(Guid id, Guid userId);
}