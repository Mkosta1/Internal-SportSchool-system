using Domain;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP;


public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public DbSet<Competition> Competition { get; set; } = default!;
    public DbSet<Excercise> Excercise { get; set; } = default!;
    public DbSet<Location> Location { get; set; } = default!;
    public DbSet<Message> Message { get; set; } = default!;
    public DbSet<MonthlySubscription> Monthly_subscription { get; set; } = default!;
    public DbSet<SportsSchool> Sports_school { get; set; } = default!;
    public DbSet<Training> Training { get; set; } = default!;
    public DbSet<UserAtTraining> User_at_training { get; set; } = default!;
    public DbSet<UserGroup> User_group { get; set; } = default!;
    public DbSet<UserInGroup> User_in_group { get; set; } = default!;
    public DbSet<UserType> User_type { get; set; } = default!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // disable cascade delete
        foreach (var foreignKey in builder.Model
                    .GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
}
    
}