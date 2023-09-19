using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class UserGroupMapper : BaseMapper<BLL.DTO.UserGroup, Domain.UserGroup>
{
    public UserGroupMapper(IMapper mapper) : base(mapper)
    {
    
    }
}