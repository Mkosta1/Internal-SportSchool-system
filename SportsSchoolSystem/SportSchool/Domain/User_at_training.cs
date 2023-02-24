

namespace Domain;

public class User_at_training
{
     public int Id { get; set; }

     public DateTime Since { get; set; } = default!;
     
     public DateTime Until { get; set; } = default!;
    
     public int User_id { get; set; }
     public User? User { get; set; }
     
     public int Training_id { get; set; }
     public Training? Training { get; set; }
}