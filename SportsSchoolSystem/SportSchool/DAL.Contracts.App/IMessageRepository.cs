using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface IMessageRepository: IBaseRepository<Message>
{
    public Task<IEnumerable<Message>> AllAsync(Guid userId);
    public Task<Message?> FindAsync(Guid id, Guid userId);
}