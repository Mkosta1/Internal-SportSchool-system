using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class UserAtCompetitionMapper : BaseMapper<BLL.DTO.UserAtCompetition, Domain.UserAtCompetition>
{
    public UserAtCompetitionMapper(IMapper mapper) : base(mapper)
    {
    
    }
    
}