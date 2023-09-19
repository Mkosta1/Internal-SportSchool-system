using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class LocationMapper : BaseMapper<BLL.DTO.Location, Public.DTO.v1.v1.Location>
{
    public LocationMapper(IMapper mapper) : base(mapper)
    {


    }
}