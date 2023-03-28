﻿using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class MessageRepository
    : EfBaseRepository<Message, ApplicationDbContext>, IMessageRepository
{
    public MessageRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
    public override async Task<IEnumerable<Message>> AllAsync()
    {
        return await RepositoryDbSet.Include(e => e.Id)
            .OrderBy(e => e.Date)
            .ToListAsync();
    }

    public override async Task<Message?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}