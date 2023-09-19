using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class LocationService : 
    BaseEntityService<BLL.DTO.Location, Domain.Location, ILocationRepository>, ILocationService
{
    protected IAppUOW Uow;
    
    public LocationService(IAppUOW uow, IMapper<BLL.DTO.Location, Domain.Location> mapper) 
        : base(uow.LocationRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<Location>> AllAsync(Guid userId)
    {
        return (await Uow.LocationRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<Location?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.LocationRepository.FindAsync(id, userId));
    }

    public async Task<Location?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.LocationRepository.RemoveAsync(id, userId));
    }

    public  Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}