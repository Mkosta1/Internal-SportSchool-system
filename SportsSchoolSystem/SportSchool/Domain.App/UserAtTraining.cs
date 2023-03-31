

using Domain.App.Identity;
using Domain.Contracts.Base;

namespace Domain;

public class UserAtTraining : IDomainEntityId
{
     public Guid Id { get; set; }
     public AppUser? AppUser { get; set; }

     public DateTime Since { get; set; } = default!;
     
     public DateTime Until { get; set; } = default!;

     public Guid Training_id { get; set; }
     public Training? Training { get; set; }
}