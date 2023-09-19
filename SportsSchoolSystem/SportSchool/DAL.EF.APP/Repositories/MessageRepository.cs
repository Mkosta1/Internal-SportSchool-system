using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class MessageRepository
    : EFBaseRepository<Message, ApplicationDbContext>, IMessageRepository
{
    public MessageRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<Message>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.SportsSchool)
            .OrderBy(e => e.Date)
            .ToListAsync();
    }

    public override async Task<Message?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<Message>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .OrderBy(e => e.Date)
            .ToListAsync();
    }

    public async Task<Message?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(t => t.SportsSchool)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Message?> RemoveAsync(Guid id, Guid userId)
    {
        var message = await FindAsync(id, userId);
        return message == null ? null : Remove(message);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet.AnyAsync(t => t.Id == id && t.Id == userId);
    }
}