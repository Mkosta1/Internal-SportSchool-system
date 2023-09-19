using BLL.Base;using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class UserAtCompetitionService : 
    BaseEntityService<BLL.DTO.UserAtCompetition, Domain.UserAtCompetition, IUserAtCompetitionRepository>, IUserAtCompetitionService
{
    protected IAppUOW Uow;
    
    public UserAtCompetitionService(IAppUOW uow, IMapper<BLL.DTO.UserAtCompetition, Domain.UserAtCompetition> mapper) 
        : base(uow.UserAtCompetitionRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<UserAtCompetition>> AllAsync(Guid userId)
    {
        return (await Uow.UserAtCompetitionRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<UserAtCompetition?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.UserAtCompetitionRepository.FindAsync(id, userId));
    }

    public async Task<UserAtCompetition?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.UserAtCompetitionRepository.RemoveAsync(id, userId));
    }

    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}