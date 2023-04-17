using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity;

public class AppUser : IdentityUser<Guid>, IDomainEntityId
{


    [MaxLength(128)] 
    public string FirstName { get; set; } = default!;
    
    [MaxLength(128)] 
    public string LastName { get; set; } = default!;
    
    public ICollection<UserInGroup>? User_in_group { get; set; }
    public ICollection<UserAtTraining>? User_at_training { get; set; }
    
    
    public int Monthly_subscription_Id { get; set; }
    public MonthlySubscription? Monthly_subscription { get; set; }
    
    public int Sports_school_Id { get; set; }
    public SportsSchool? SportsSchool { get; set; }
    
    public int Competition_Id { get; set; }
    public Competition? Competition { get; set; }
    
    public int User_type_Id { get; set; }
    public UserType? User_type { get; set; }

    public ICollection<AppRefreshToken>? AppRefreshTokens { get; set; }
    
    
    
}