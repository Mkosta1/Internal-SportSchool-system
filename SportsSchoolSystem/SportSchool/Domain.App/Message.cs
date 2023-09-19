using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App;

public class Message : DomainEntityId
{

    [MinLength(1)]
    [MaxLength(128)]
    public string Subject { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(1000)]
    public string Content { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;
    
    public ICollection<SportsSchool>? SportsSchool { get; set; }
}