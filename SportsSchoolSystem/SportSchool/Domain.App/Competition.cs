using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using Domain.Base;
using Domain.Contracts.Base;


namespace Domain;

public class Competition : DomainEntityId
{

    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public int Group_size { get; set; } = default!;
    
    public DateTime Since { get; set; } = default!;

    public DateTime Until { get; set; } = default!;

    public ICollection<AppUser>? AppUser { get; set; }
    
    public Guid Location_id { get; set; }
    public Location? Location { get; set; }
    
}