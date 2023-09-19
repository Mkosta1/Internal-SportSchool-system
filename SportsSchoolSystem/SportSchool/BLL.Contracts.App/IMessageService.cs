using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;


public interface IMessageService : IBaseRepository<BLL.DTO.Message>, IMessageRepositoryCustom<BLL.DTO.Message>
{
    
    
}