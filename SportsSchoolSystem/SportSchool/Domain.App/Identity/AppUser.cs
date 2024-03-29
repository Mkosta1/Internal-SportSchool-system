﻿using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity;

public class AppUser : IdentityUser<Guid>, IDomainEntityId
{


    [MaxLength(128)] 
    public string FirstName { get; set; } = default!;
    
    [MaxLength(128)] 
    public string LastName { get; set; } = default!;
    
    public ICollection<UserAtTraining>? UserAtTraining { get; set; }
    
    public ICollection<UserAtCompetition>? UserAtCompetition { get; set; }
    
    public Guid? MonthlySubscriptionId { get; set; }
    public MonthlySubscription? MonthlySubscription { get; set; }
    
    public Guid? SportsSchoolId { get; set; }
    public SportsSchool? SportsSchool { get; set; }

    public ICollection<AppRefreshToken>? AppRefreshTokens { get; set; }
    
    
    
}