using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IUserAtCompetitionService: IBaseRepository<BLL.DTO.UserAtCompetition>, IUserAtCompetitionRepositoryCustom<BLL.DTO.UserAtCompetition>
{
    
}