using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class UserInGroupMapper : BaseMapper<BLL.DTO.UserInGroup, Public.DTO.v1.v1.UserInGroup>
{
    public UserInGroupMapper(IMapper mapper) : base(mapper)
    {


    }
}