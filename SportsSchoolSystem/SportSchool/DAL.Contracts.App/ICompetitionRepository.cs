﻿using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface ICompetitionRepository : IBaseRepository<Competition>
{
    public Task<IEnumerable<Competition>> AllAsync(Guid userId);
    public Task<Competition?> FindAsync(Guid id, Guid userId);

}