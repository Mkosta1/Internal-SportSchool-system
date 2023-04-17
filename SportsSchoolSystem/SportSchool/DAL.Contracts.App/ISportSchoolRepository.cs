using DAL.Contracts.Base;
using Domain;

namespace DAL.Contracts.App;

public interface ISportSchoolRepository : IBaseRepository<SportsSchool>
{
    public Task<IEnumerable<SportsSchool>> AllAsync(Guid userId);
    public Task<SportsSchool?> FindAsync(Guid id, Guid userId);
}