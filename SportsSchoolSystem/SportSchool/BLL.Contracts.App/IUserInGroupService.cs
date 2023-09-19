using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;


public interface IUserInGroupService : IBaseRepository<BLL.DTO.UserInGroup>, IUserInGroupRepositoryCustom<BLL.DTO.UserInGroup>
{
    
    
}