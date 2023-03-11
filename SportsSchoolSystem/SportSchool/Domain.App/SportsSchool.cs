﻿using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;

namespace Domain;

public class SportsSchool
{
    
    public int Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Address { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(12)]
    public string PhoneNumber { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(128)]
    public string Email { get; set; } = default!;

    public ICollection<Training>? Training { get; set; }
    
    public ICollection<AppUser>? AppUsers { get; set; }
    
    public ICollection<MonthlySubscription>? MonthlySubscriptions { get; set; }
    
    public int Message_id { get; set; }
    public Message? Message { get; set; }
    
}