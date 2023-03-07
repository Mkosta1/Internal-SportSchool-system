using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User
{
    public int Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(64)]
    public string FirstName { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(128)]
    public string LastName { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Email { get; set; } = default!;

    
    

    public ICollection<User_at_training>? User_at_training { get; set; }
    
    public ICollection<User_in_group>? User_in_group { get; set; }
    
    public int Sports_school_id { get; set; }
    public Sports_school? Sports_school { get; set; }
    
    public int User_type_id { get; set; }
    public User_type? User_type { get; set; }
    
    public int Competition_id { get; set; }
    public Competition? Competition { get; set; }
    
    public int Monthly_subscription_id { get; set; }
    public Monthly_subscription? Monthly_subscription { get; set; }
    
    
    
    
    
}