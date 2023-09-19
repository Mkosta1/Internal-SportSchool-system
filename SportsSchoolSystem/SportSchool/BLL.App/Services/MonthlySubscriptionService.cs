using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class MonthlySubscriptionService : 
    BaseEntityService<BLL.DTO.MonthlySubscription, Domain.MonthlySubscription, IMonthlySubscriptionRepository>, IMonthlySubscriptionService
{
    protected IAppUOW Uow;
    
    public MonthlySubscriptionService(IAppUOW uow, IMapper<BLL.DTO.MonthlySubscription, Domain.MonthlySubscription> mapper) 
        : base(uow.MonthlySubscriptionRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<MonthlySubscription>> AllAsync(Guid userId)
    {
        return (await Uow.MonthlySubscriptionRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<MonthlySubscription?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.MonthlySubscriptionRepository.FindAsync(id, userId));
    }

    public async Task<MonthlySubscription?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.MonthlySubscriptionRepository.RemoveAsync(id, userId));
    }

    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}