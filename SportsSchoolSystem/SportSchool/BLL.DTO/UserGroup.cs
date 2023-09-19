using System.ComponentModel.DataAnnotations;
using Domain;
using Domain.Base;

namespace BLL.DTO;

public class UserGroup : DomainEntityId
{

    [MinLength(1)]
    [MaxLength(64)]
    public string Name { get; set; } = default!;
    
    public int Size { get; set; } = default!;
    
    public ICollection<UserInGroup>? UserInGroup { get; set; }
}