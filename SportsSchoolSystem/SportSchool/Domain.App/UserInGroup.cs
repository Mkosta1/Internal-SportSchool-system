using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using Domain.Base;
using Domain.Contracts.Base;


namespace Domain;

public class UserInGroup : DomainEntityId
{
    public AppUser? AppUser { get; set; }
    public Guid? AppUserId { get; set; }
    
    
    public DateTime Since { get; set; } = default!;
    public DateTime Until { get; set; } = default!;
    
    
    public Guid UserGroupId { get; set; }
    public UserGroup? UserGroup { get; set; }
}