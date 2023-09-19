using Domain.App.Identity;

namespace Public.DTO.v1.v1;

public class UserInGroup
{
    public Guid Id { get; set; }
    
    public DateTime Since { get; set; } = default!;
    public DateTime Until { get; set; } = default!;
    
    
    public Guid UserGroupId { get; set; }
    
    public Guid AppUserId { get; set; }
    
}