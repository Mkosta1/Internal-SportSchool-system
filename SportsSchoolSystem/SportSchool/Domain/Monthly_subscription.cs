﻿using System.ComponentModel.DataAnnotations;


namespace Domain;

public class Monthly_subscription
{
    public int Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public double Price { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;
    
    public ICollection<User>? User { get; set; }
    
    public int Sports_school_id { get; set; }
    public Sports_school? Sports_school { get; set; }
}