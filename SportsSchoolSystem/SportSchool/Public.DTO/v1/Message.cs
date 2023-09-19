using System.ComponentModel.DataAnnotations;

namespace Public.DTO.v1.v1;

public class Message
{
    public Guid Id { get; set; }

    [MinLength(1)]
    [MaxLength(128)]
    public string Subject { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(1000)]
    public string Content { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;
    
}