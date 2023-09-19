using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class UserAtTrainingMapper : BaseMapper<BLL.DTO.UserAtTraining, Public.DTO.v1.v1.UserAtTraining>
{
    public UserAtTrainingMapper(IMapper mapper) : base(mapper)
    {


    }
}