using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using Domain.Contracts.Base;


namespace Domain;

public class UserInGroup : IDomainEntityId
{

    public Guid Id { get; set; }
    public AppUser? AppUser { get; set; }
    
    
    public DateTime Since { get; set; } = default!;
    public DateTime Until { get; set; } = default!;
    
    
    public Guid User_group_id { get; set; }
    public UserGroup? User_group { get; set; }
}