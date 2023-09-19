using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class UserAtTrainingMapper : BaseMapper<BLL.DTO.UserAtTraining, Domain.UserAtTraining>
{
    public UserAtTrainingMapper(IMapper mapper) : base(mapper)
    {
    
    }
}