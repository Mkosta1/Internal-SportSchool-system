using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;


public interface ILocationService : IBaseRepository<BLL.DTO.Location>, ILocationRepositoryCustom<BLL.DTO.Location>
{
    
    
}