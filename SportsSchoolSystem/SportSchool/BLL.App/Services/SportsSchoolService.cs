using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class SportsSchoolService : 
    BaseEntityService<BLL.DTO.SportsSchool, Domain.SportsSchool, ISportSchoolRepository>, ISportsSchoolService
{
    protected IAppUOW Uow;
    
    public SportsSchoolService(IAppUOW uow, IMapper<BLL.DTO.SportsSchool, Domain.SportsSchool> mapper) 
        : base(uow.SportSchoolRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<SportsSchool>> AllAsync(Guid userId)
    {
        return (await Uow.SportSchoolRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<SportsSchool?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.SportSchoolRepository.FindAsync(id, userId));
    }

    public async Task<SportsSchool?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.SportSchoolRepository.RemoveAsync(id, userId));
    }

    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}