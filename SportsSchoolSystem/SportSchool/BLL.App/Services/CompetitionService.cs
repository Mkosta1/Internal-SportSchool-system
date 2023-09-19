using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class CompetitionService : 
    BaseEntityService<BLL.DTO.Competition, Domain.Competition, ICompetitionRepository>, ICompetitionService
{
    protected IAppUOW Uow;

    public CompetitionService(IAppUOW uow, IMapper<BLL.DTO.Competition, Domain.Competition> mapper) 
        : base(uow.CompetitionRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<Competition>> AllAsync(Guid userId)
    {
        return (await Uow.CompetitionRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }
    
    public async Task<Competition?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.CompetitionRepository.FindAsync(id, userId));
    }

    public async Task<Competition?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.CompetitionRepository.RemoveAsync(id, userId));
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}