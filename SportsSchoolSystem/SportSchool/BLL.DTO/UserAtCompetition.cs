using Domain.App.Identity;
using Domain.Base;

namespace BLL.DTO;

public class UserAtCompetition  : DomainEntityId
{
    public DateTime? Since { get; set; } = default!;

    public DateTime? Until { get; set; } = default!;

    public Guid CompetitionId { get; set; }
    public Competition? Competition { get; set; }

    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}