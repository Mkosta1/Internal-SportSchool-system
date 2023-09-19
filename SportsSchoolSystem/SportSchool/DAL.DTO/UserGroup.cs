

namespace DAL.DTO;

public class UserGroup
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
    
    public int Size { get; set; } = default!;
    
    public ICollection<UserInGroup>? UserInGroup { get; set; }
}