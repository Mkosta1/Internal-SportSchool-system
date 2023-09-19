using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;


public interface ITrainingService : IBaseRepository<BLL.DTO.Training>, ITrainingRepositoryCustom<BLL.DTO.Training>
{
    
    
}