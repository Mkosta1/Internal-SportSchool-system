using Domain.App.Identity;

namespace DAL.DTO;

public class UserAtCompetition
{
    public Guid Id { get; set; }
    
    public DateTime? Since { get; set; } = default!;

    public DateTime? Until { get; set; } = default!;

    public Guid CompetitionId { get; set; }
    public Competition? Competition { get; set; }

    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}