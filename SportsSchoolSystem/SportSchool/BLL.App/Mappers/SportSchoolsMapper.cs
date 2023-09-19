using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;


public class SportSchoolsMapper : BaseMapper<BLL.DTO.SportsSchool, Domain.SportsSchool>
{
    public SportSchoolsMapper(IMapper mapper) : base(mapper)
    {
    
    }
}