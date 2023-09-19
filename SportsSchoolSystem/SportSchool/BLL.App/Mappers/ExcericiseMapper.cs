using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;


public class ExcerciseMapper : BaseMapper<BLL.DTO.Excercise, Domain.Excercise>
{
    public ExcerciseMapper(IMapper mapper) : base(mapper)
    {
    
    }
}
