using System.ComponentModel.DataAnnotations;
using Domain;
using Domain.App.Identity;
using Domain.Base;

namespace BLL.DTO;

public class MonthlySubscription : DomainEntityId
{

    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public double Price { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;
    
    
    public ICollection<AppUser>? AppUsers { get; set; }
    
    public Guid SportsSchoolId { get; set; }
    public SportsSchool? SportsSchool { get; set; }
}