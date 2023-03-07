using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Training
{
    
    public int Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public int Duration { get; set; } = default!;
    
    public ICollection<User_at_training>? User_at_training { get; set; }
    
    public int Location_id { get; set; }
    public Location? Location { get; set; }
    
    public int Excercise_id { get; set; }
    public Excercise? Excercise { get; set; }
    
    public int Sports_school_id { get; set; }
    public Sports_school? Sports_school { get; set; }

}