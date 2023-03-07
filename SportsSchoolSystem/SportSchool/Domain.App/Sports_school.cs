using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Sports_school
{
    
    public int Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Address { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(12)]
    public string PhoneNumber { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Email { get; set; } = default!;
    
    public ICollection<User>? User { get; set; }
    
    public ICollection<Training>? Training { get; set; }
    
    public ICollection<Monthly_subscription>? MonthlySubscriptions { get; set; }
    
    public int Message_id { get; set; }
    public Message? Message { get; set; }
    
}