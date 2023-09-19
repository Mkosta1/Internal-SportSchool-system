using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.Contracts.Base;

namespace Domain;

public class Excercise : DomainEntityId
{
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public int Duration { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Level { get; set; } = default!;
    
    public ICollection<Training>? Training { get; set; }
    
}