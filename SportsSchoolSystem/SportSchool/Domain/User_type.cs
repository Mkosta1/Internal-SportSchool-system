using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;


namespace Domain;

public class User_type
{
    
    public int Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(64)]
    public string Name { get; set; } = default!;
    
    public DateTime Since { get; set; } = default!;

    public DateTime Until { get; set; } = default!;
    
    public ICollection<User>? User { get; set; }
}