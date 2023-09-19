using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class MessageService : 
    BaseEntityService<BLL.DTO.Message, Domain.App.Message, IMessageRepository>, IMessageService
{
    protected IAppUOW Uow;
    
    public MessageService(IAppUOW uow, IMapper<BLL.DTO.Message, Domain.App.Message> mapper) 
        : base(uow.MessageRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<Message>> AllAsync(Guid userId)
    {
        return (await Uow.MessageRepository.AllAsync(userId)).Select(e => Mapper.Map(e));
    }

    public async Task<Message?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.MessageRepository.FindAsync(id, userId));
    }

    public async Task<Message?> RemoveAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.MessageRepository.RemoveAsync(id, userId));
    }

    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}