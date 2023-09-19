using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class UserInGroupMapper : BaseMapper<BLL.DTO.UserInGroup, Domain.UserInGroup>
{
    public UserInGroupMapper(IMapper mapper) : base(mapper)
    {
    
    }
}