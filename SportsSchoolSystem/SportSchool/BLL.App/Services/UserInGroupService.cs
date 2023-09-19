using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class UserInGroupService : 
    BaseEntityService<BLL.DTO.UserInGroup, Domain.UserInGroup, IUserInGroupRepository>, IUserInGroupService
{
    protected IAppUOW Uow;
    
    public UserInGroupService(IAppUOW uow, IMapper<BLL.DTO.UserInGroup, Domain.UserInGroup> mapper) 
        : base(uow.UserInGroupRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<UserInGroup>> AllAsync(Guid userId)
    {
        return (await Uow.UserInGroupRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<UserInGroup?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.UserInGroupRepository.FindAsync(id, userId));
    }

    public async Task<UserInGroup?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.UserInGroupRepository.RemoveAsync(id, userId));
    }

    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}