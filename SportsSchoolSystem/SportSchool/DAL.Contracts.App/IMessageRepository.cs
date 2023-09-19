using DAL.Contracts.Base;
using Domain;
using Domain.App;

namespace DAL.Contracts.App;

public interface IMessageRepository: IBaseRepository<Message>, IMessageRepositoryCustom<Message>
{
}

public interface IMessageRepositoryCustom<TEntity>
{
    public Task<IEnumerable<TEntity>> AllAsync(Guid userId);
    public Task<TEntity?> FindAsync(Guid id, Guid userId);

    Task<TEntity?> RemoveAsync(Guid id, Guid userId);
    
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
}