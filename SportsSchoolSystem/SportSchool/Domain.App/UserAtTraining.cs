

using Domain.App.Identity;
using Domain.Base;
using Domain.Contracts.Base;

namespace Domain;

public class UserAtTraining : DomainEntityId
{
     public Guid? AppUserId { get; set; }
     public AppUser? AppUser { get; set; }

     public DateTime? Since { get; set; } = default!;
     
     public DateTime? Until { get; set; } = default!;

     public Guid TrainingId { get; set; }
     public Training? Training { get; set; }
     
     
}