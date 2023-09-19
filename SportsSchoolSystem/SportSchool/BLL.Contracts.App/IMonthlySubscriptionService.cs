using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;



public interface IMonthlySubscriptionService : IBaseRepository<BLL.DTO.MonthlySubscription>, IMonthlySubscriptionRepositoryCustom<BLL.DTO.MonthlySubscription>
{
    
    
}