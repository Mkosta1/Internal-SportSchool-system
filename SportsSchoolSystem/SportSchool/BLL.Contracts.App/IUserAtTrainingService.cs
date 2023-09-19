using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;


public interface IUserAtTrainingService : IBaseRepository<BLL.DTO.UserAtTraining>, IUserAtTrainingRepositoryCustom<BLL.DTO.UserAtTraining>
{
    
    
}