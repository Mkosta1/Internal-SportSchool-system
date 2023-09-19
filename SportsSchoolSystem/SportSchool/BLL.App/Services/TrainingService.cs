using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class TrainingService : 
    BaseEntityService<BLL.DTO.Training, Domain.Training, ITrainingRepository>, ITrainingService
{
    protected IAppUOW Uow;
    
    public TrainingService(IAppUOW uow, IMapper<BLL.DTO.Training, Domain.Training> mapper) 
        : base(uow.TrainingRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<Training>> AllAsync(Guid userId)
    {
        return (await Uow.TrainingRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<Training?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.TrainingRepository.FindAsync(id, userId));
    }

    public async Task<Training?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.TrainingRepository.RemoveAsync(id, userId));
    }

    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}