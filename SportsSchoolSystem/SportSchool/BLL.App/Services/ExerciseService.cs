using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class ExcerciseService : 
    BaseEntityService<BLL.DTO.Excercise, Domain.Excercise, IExcerciseRepository>, IExcerciseService
{
    
    protected IAppUOW Uow;
    
    public ExcerciseService(IAppUOW uow, IMapper<BLL.DTO.Excercise, Domain.Excercise> mapper) 
        : base(uow.ExcerciseRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<Excercise>> AllAsync(Guid userId)
    {
        return (await Uow.ExcerciseRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<Excercise?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.ExcerciseRepository.FindAsync(id, userId));
    }

    public async Task<Excercise?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.ExcerciseRepository.RemoveAsync(id, userId));
    }

    public  Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}