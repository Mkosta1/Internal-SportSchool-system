using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;


namespace Domain;

public class Message : IDomainEntityId
{
    public Guid Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Subject { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(1000)]
    public string Content { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;
    
    public ICollection<SportsSchool>? Sports_school { get; set; }
}