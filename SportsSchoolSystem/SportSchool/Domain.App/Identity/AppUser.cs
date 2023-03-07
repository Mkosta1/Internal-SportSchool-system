using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity;

public class AppUser : IdentityRole<Guid>, IDomainEntityId
{
    
}