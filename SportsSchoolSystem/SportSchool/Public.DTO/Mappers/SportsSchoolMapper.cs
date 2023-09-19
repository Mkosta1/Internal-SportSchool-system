using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class SportsSchoolMapper : BaseMapper<BLL.DTO.SportsSchool, Public.DTO.v1.v1.SportsSchool>
{
    public SportsSchoolMapper(IMapper mapper) : base(mapper)
    {


    }
}