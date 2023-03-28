using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Domain.App.Identity;
using Domain.Contracts.Base;


namespace Domain;

public class UserType  : IDomainEntityId
{
    
    public Guid Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(64)]
    public string Name { get; set; } = default!;
    
    public DateTime Since { get; set; } = default!;

    public DateTime Until { get; set; } = default!;
    
    
    public ICollection<AppUser>? AppUsers { get; set; }
}