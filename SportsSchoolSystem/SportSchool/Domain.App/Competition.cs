using System.ComponentModel.DataAnnotations;
using Domain.App;
using Domain.App.Identity;
using Domain.Base;
using Domain.Contracts.Base;


namespace Domain;

public class Competition : DomainEntityId
{

    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public int GroupSize { get; set; } = default!;
    
    public DateTime Since { get; set; } = default!;

    public DateTime Until { get; set; } = default!;

    public ICollection<UserAtCompetition>? UserAtCompetition { get; set; }
    
    public Guid LocationId { get; set; }
    public Location? Location { get; set; }
    
}