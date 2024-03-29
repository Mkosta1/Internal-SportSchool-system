﻿using DAL.Contracts.App;
using DAL.EF.Base;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Repositories;

public class CompetitionRepository
    : EFBaseRepository<Competition, ApplicationDbContext>, ICompetitionRepository
{

    public CompetitionRepository(ApplicationDbContext dataContext) : base(dataContext)
    {

    }

    public override async Task<IEnumerable<Competition>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.UserAtCompetition)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public override async Task<Competition?> FindAsync(Guid id)
    { 
        return await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<IEnumerable<Competition>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public virtual async Task<Competition?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(t => t.UserAtCompetition)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Competition?> RemoveAsync(Guid id, Guid userId)
    {
        var competition = await FindAsync(id, userId);
        return competition == null ? null : Remove(competition);

    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet.AnyAsync(t => t.Id == id && t.Id == userId);
    }
} 