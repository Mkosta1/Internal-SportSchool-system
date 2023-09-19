using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;


public class MonthlySubscriptionMapper : BaseMapper<BLL.DTO.MonthlySubscription, Domain.MonthlySubscription>
{
    public MonthlySubscriptionMapper(IMapper mapper) : base(mapper)
    {
    
    }
}