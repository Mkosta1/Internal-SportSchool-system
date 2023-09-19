namespace Public.DTO.v1.v1;

public class Training
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
    
    public int Duration { get; set; } = default!;
    
    public DateTime Since { get; set; } = default!;
     
    public DateTime Until { get; set; } = default!;
    
    public Guid LocationId { get; set; }

    public Guid ExcerciseId { get; set; }
    
    public Guid? SportsSchoolId { get; set; }
   
}