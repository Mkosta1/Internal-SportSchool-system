﻿using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;

namespace Domain;

public class UserGroup : IDomainEntityId
{
    public Guid Id { get; set; }
    
    [MinLength(1)]
    [MaxLength(64)]
    public string Name { get; set; } = default!;
    
    public int Size { get; set; } = default!;
    
    public ICollection<UserInGroup>? User_in_group { get; set; }
}