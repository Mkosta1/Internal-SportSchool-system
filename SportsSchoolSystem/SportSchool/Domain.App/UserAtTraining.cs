

using Domain.App.Identity;
using Domain.Base;
using Domain.Contracts.Base;

namespace Domain;

public class UserAtTraining : DomainEntityId
{
     public AppUser? AppUser { get; set; }

     public DateTime Since { get; set; } = default!;
     
     public DateTime Until { get; set; } = default!;

     public Guid Training_id { get; set; }
     public Training? Training { get; set; }
}