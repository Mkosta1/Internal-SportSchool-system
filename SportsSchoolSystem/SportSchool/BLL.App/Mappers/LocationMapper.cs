using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;


public class LocationMapper : BaseMapper<BLL.DTO.Location, Domain.Location>
{
    public LocationMapper(IMapper mapper) : base(mapper)
    {
    
    }
}
