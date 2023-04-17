using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IUserInGroupRepository : IBaseRepository<UserInGroup>
{
    public Task<IEnumerable<UserInGroup>> AllAsync(Guid userId);
    public Task<UserInGroup?> FindAsync(Guid id, Guid userId); 
}