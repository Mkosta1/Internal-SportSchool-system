namespace Public.DTO.v1.v1;

public class SportsSchool
{
    public Guid Id { get; set; }
    
    public string Address { get; set; } = default!;
    
    public string PhoneNumber { get; set; } = default!;
    
    public string Email { get; set; } = default!;

    public Guid MessageId { get; set; }
}