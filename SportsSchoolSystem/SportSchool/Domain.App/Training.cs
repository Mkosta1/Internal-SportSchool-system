using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;

namespace Domain;

public class Training : IDomainEntityId
{
    
    public Guid Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public int Duration { get; set; } = default!;
    
    public ICollection<UserAtTraining>? UserAtTrainings { get; set; }
    
    public int Location_id { get; set; }
    public Location? Location { get; set; }
    
    public int Excercise_id { get; set; }
    public Excercise? Excercise { get; set; }
    
    public int Sports_school_id { get; set; }
    public SportsSchool? Sports_school { get; set; }

}