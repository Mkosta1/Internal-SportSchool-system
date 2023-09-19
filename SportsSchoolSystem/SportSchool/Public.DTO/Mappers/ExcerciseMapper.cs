using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class ExcerciseMapper : BaseMapper<BLL.DTO.Excercise, Public.DTO.v1.v1.Excercise>
{
    public ExcerciseMapper(IMapper mapper) : base(mapper)
    {


    }
}