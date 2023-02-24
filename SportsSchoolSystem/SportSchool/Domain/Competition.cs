﻿using System.ComponentModel.DataAnnotations;


namespace Domain;

public class Competition
{
    public int Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    public int Group_size { get; set; } = default!;
    
    public DateTime Since { get; set; } = default!;

    public DateTime Until { get; set; } = default!;
    
    public ICollection<User>? User { get; set; }
    
    public int Location_id { get; set; }
    public Location? Location { get; set; }
    
}