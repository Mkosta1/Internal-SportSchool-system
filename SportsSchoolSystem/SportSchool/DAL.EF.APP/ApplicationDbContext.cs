using Domain;
using Domain.App;
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
    public DbSet<MonthlySubscription> MonthlySubscription { get; set; } = default!;
    public DbSet<SportsSchool> SportsSchool { get; set; } = default!;
    public DbSet<Training> Training { get; set; } = default!;
    public DbSet<UserAtTraining> UserAtTraining { get; set; } = default!;
    public DbSet<UserGroup> UserGroup { get; set; } = default!;
    public DbSet<UserInGroup> UserInGroup { get; set; } = default!;

    public DbSet<UserAtCompetition> UserAtCompetition { get; set; } = default!;
   
    public DbSet<AppRefreshToken> AppRefreshTokens { get; set; } = default!;
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