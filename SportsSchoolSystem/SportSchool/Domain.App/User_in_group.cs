using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using Domain.Contracts.Base;


namespace Domain;

public class User_in_group : IDomainEntityId
{

    public Guid Id { get; set; }
    public AppUser? AppUser { get; set; }
    
    
    public DateTime Since { get; set; } = default!;
    public DateTime Until { get; set; } = default!;
    
    
    public int User_group_id { get; set; }
    public User_group? User_group { get; set; }
}