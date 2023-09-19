using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface ICompetitionService : IBaseRepository<BLL.DTO.Competition>, ICompetitionRepositoryCustom<BLL.DTO.Competition>
{
    
    
}