using Domain.App.Identity;

namespace DAL.DTO;

public class UserInGroup
{
    public Guid Id { get; set; }
    
    public DateTime Since { get; set; } = default!;
    public DateTime Until { get; set; } = default!;
    
    
    public Guid UserGroupId { get; set; }
    public UserGroup? UserGroup { get; set; }
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}