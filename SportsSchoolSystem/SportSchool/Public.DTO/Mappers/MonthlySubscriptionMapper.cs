using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class MonthlySubscriptionMapper : BaseMapper<BLL.DTO.MonthlySubscription, Public.DTO.v1.v1.MonthlySubscription>
{
    public MonthlySubscriptionMapper(IMapper mapper) : base(mapper)
    {


    }
}