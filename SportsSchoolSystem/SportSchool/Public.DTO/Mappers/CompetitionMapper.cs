using AutoMapper;
using DAL.Base;

namespace Public.DTO.v1.Mappers;

public class CompetitionMapper : BaseMapper<BLL.DTO.Competition, Public.DTO.v1.v1.Competition>
{
    public CompetitionMapper(IMapper mapper) : base(mapper)
    {
        
        
    }

    // Public.DTO.v1.v1.Competition? MapWithCount(Domain.Competition entity)
    // {
    //
    //     var res = Map(entity);
    //     
    //     return res;
    //
    // }
}