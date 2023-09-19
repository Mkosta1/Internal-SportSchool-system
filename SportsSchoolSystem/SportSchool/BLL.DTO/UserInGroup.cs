using Domain.App.Identity;
using Domain.Base;

namespace BLL.DTO;

public class UserInGroup : DomainEntityId
{
    public Guid? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    
    
    public DateTime Since { get; set; } = default!;
    public DateTime Until { get; set; } = default!;
    
    
    public Guid UserGroupId { get; set; }
    public UserGroup? UserGroup { get; set; }
}