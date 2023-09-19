using System.ComponentModel.DataAnnotations;
using Domain;
using Domain.Base;

namespace BLL.DTO;

public class Location : DomainEntityId
{

    [MinLength(1)]
    [MaxLength(64)]
    public string Name { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(64)]
    public string Address { get; set; } = default!;
    
    public ICollection<Training>? Training { get; set; }
    
    public ICollection<Competition>? Competition { get; set; }
}