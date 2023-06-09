﻿using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.Contracts.Base;

namespace Domain;

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