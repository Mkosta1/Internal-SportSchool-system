using Domain.App.Identity;

namespace DAL.DTO;

public class UserAtTraining
{
    public Guid Id { get; set; }
    
    public DateTime? Since { get; set; } = default!;
     
    public DateTime? Until { get; set; } = default!;

    public Guid TrainingId { get; set; }
    public Training? Training { get; set; }
    
    public Guid? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}