using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class TrainingMapper : BaseMapper<BLL.DTO.Training, Public.DTO.v1.v1.Training>
{
    public TrainingMapper(IMapper mapper) : base(mapper)
    {


    }
}