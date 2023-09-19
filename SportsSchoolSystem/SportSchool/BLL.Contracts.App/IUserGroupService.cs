using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;


public interface IUserGroupService : IBaseRepository<BLL.DTO.UserGroup>, IUserGroupRepositoryCustom<BLL.DTO.UserGroup>
{
    
    
}