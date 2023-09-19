using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;



public interface ISportsSchoolService : IBaseRepository<BLL.DTO.SportsSchool>, ISportsSchoolRepositoryCustom<BLL.DTO.SportsSchool>
{
    
    
}