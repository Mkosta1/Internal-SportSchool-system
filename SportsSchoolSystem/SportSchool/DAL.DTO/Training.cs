

namespace DAL.DTO;

public class Training
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
    
    public int Duration { get; set; } = default!;
    
    public DateTime Since { get; set; } = default!;
     
    public DateTime Until { get; set; } = default!;
    
    public ICollection<UserAtTraining>? UserAtTrainings { get; set; }
    
    public Guid LocationId { get; set; }
    public Location? Location { get; set; }
    
    public Guid ExcerciseId { get; set; }
    public Excercise? Excercise { get; set; }
    
    public Guid? SportsSchoolId { get; set; }
    public SportsSchool? SportsSchool { get; set; }
}