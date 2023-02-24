using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User_group
{
    public int Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(64)]
    public string Name { get; set; } = default!;
    
    public int Size { get; set; } = default!;
    
    public ICollection<User_in_group>? User_in_group { get; set; }
}