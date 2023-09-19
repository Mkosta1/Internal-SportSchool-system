namespace Public.DTO.v1.v1;

public class MonthlySubscription
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
    
    public double Price { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;

    public Guid SportsSchoolId { get; set; }
}