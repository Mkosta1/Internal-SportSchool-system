using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class UserAtCompetitionMapper: BaseMapper<BLL.DTO.UserAtCompetition, Public.DTO.v1.v1.UserAtCompetition>
{
    public UserAtCompetitionMapper(IMapper mapper) : base(mapper)
    {


    }
}