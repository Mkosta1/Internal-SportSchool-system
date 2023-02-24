using System.ComponentModel.DataAnnotations;


namespace Domain;

public class User_in_group
{
    public int Id { get; set; }
    
    public DateTime Since { get; set; } = default!;
    public DateTime Until { get; set; } = default!;
    
    public int User_id { get; set; }
    public User? User { get; set; }
    
    public int User_group_id { get; set; }
    public User_group? User_group { get; set; }
    
}