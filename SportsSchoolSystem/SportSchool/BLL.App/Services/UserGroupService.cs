using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class UserGroupService : 
    BaseEntityService<BLL.DTO.UserGroup, Domain.UserGroup, IUserGroupRepository>, IUserGroupService
{
    protected IAppUOW Uow;
    
    public UserGroupService(IAppUOW uow, IMapper<BLL.DTO.UserGroup, Domain.UserGroup> mapper) 
        : base(uow.UserGroupRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<UserGroup>> AllAsync(Guid userId)
    {
        return (await Uow.UserGroupRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<UserGroup?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.UserGroupRepository.FindAsync(id, userId));
    }

    public async Task<UserGroup?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.UserGroupRepository.RemoveAsync(id, userId));
    }

    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}