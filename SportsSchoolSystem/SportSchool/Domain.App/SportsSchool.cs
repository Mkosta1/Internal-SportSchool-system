using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using Domain.Contracts.Base;

namespace Domain;

public class SportsSchool : IDomainEntityId
{
    
    public Guid Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Address { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(12)]
    public string PhoneNumber { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Email { get; set; } = default!;

    public ICollection<Training>? Training { get; set; }
    
    public ICollection<AppUser>? AppUser { get; set; }
    
    public ICollection<MonthlySubscription>? MonthlySubscriptions { get; set; }
    
    public Guid Message_id { get; set; }
    public Message? Message { get; set; }
    
}