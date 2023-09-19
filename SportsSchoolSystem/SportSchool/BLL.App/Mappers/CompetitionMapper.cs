using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class CompetitionMapper : BaseMapper<BLL.DTO.Competition, Domain.Competition>
{
    public CompetitionMapper(IMapper mapper) : base(mapper)
    {
        
    }
}