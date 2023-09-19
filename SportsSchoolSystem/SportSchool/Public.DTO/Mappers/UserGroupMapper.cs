using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class UserGroupMapper : BaseMapper<BLL.DTO.UserGroup, Public.DTO.v1.v1.UserGroup>
{
    public UserGroupMapper(IMapper mapper) : base(mapper)
    {


    }
}