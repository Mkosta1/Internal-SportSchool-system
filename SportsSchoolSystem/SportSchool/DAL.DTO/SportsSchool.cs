

namespace DAL.DTO;

public class SportsSchool
{
    public Guid Id { get; set; }
    
    public string Address { get; set; } = default!;
    
    public string PhoneNumber { get; set; } = default!;
    
    public string Email { get; set; } = default!;

    public ICollection<Training>? Training { get; set; }

    public ICollection<MonthlySubscription>? MonthlySubscriptions { get; set; }
    
    public Guid MessageId { get; set; }
}