using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;


public interface IExcerciseService : IBaseRepository<BLL.DTO.Excercise>, IExcerciseRepositoryCustom<BLL.DTO.Excercise>
{
    
    
}