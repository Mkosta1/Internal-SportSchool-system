using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class UserAtTrainingService : 
    BaseEntityService<BLL.DTO.UserAtTraining, Domain.UserAtTraining, IUserAtTrainingRepository>, IUserAtTrainingService
{
    protected IAppUOW Uow;
    
    public UserAtTrainingService(IAppUOW uow, IMapper<BLL.DTO.UserAtTraining, Domain.UserAtTraining> mapper) 
        : base(uow.UserAtTrainingRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<UserAtTraining>> AllAsync(Guid userId)
    {
        return (await Uow.UserAtTrainingRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<UserAtTraining?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.UserAtTrainingRepository.FindAsync(id, userId));
    }

    public async Task<UserAtTraining?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.UserAtTrainingRepository.RemoveAsync(id, userId));
    }

    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}