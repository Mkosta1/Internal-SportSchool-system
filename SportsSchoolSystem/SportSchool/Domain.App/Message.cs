using System.ComponentModel.DataAnnotations;


namespace Domain;

public class Message
{
    public int Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Subject { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(1000)]
    public string Content { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;
    
    public ICollection<SportsSchool>? Sports_school { get; set; }
}