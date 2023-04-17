using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.Contracts.Base;

namespace Domain;

public class Training : DomainEntityId
{
    
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public int Duration { get; set; } = default!;
    
    public ICollection<UserAtTraining>? UserAtTrainings { get; set; }
    
    public Guid Location_id { get; set; }
    public Location? Location { get; set; }
    
    public Guid Excercise_id { get; set; }
    public Excercise? Excercise { get; set; }
    
    public Guid Sports_school_id { get; set; }
    public SportsSchool? Sports_school { get; set; }

}