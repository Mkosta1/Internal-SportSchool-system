
namespace DAL.DTO;

public class Location
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    
    public string Address { get; set; } = default!;
    
    public ICollection<Training>? Training { get; set; }
    
    public ICollection<Competition>? Competition { get; set; }
}