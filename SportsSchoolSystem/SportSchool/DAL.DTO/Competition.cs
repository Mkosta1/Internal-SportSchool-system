using System.ComponentModel.DataAnnotations;

namespace DAL.DTO;

public class Competition
{
    public Guid Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public int GroupSize { get; set; } = default!;
    
    public DateTime Since { get; set; } = default!;

    public DateTime Until { get; set; } = default!;
    
    public Guid LocationId { get; set; }
    
    public ICollection<UserAtCompetition>? UserAtCompetition { get; set; }
}