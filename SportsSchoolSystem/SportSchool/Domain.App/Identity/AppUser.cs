using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity;

public class AppUser : IdentityUser<Guid>, IDomainEntityId
{

    public ICollection<User_in_group>? User_in_group { get; set; }
    public ICollection<User_at_training>? User_at_training { get; set; }
    
    
    public Guid Monthly_subscription_Id { get; set; }
    public Monthly_subscription? Monthly_subscription { get; set; }
    
    public Guid Sports_school_Id { get; set; }
    public Sports_school? SportsSchool { get; set; }
    
    public Guid Competition_Id { get; set; }
    public Competition? Competition { get; set; }
    
    public Guid User_type_Id { get; set; }
    public User_type? User_type { get; set; }
    
    
    
}