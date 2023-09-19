using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class TrainingMapper : BaseMapper<BLL.DTO.Training, Domain.Training>
{
    public TrainingMapper(IMapper mapper) : base(mapper)
    {
    
    }
}