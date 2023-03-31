using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using Domain.Contracts.Base;


namespace Domain;

public class MonthlySubscription : IDomainEntityId
{
    public Guid Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public double Price { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;
    
    
    public ICollection<AppUser>? AppUsers { get; set; }
    
    public Guid Sports_school_id { get; set; }
    public SportsSchool? Sports_school { get; set; }
}