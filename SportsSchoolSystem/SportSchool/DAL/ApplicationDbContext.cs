using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL;


public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Competition> Competition { get; set; } = default!;
    public DbSet<Excercise> Excercise { get; set; } = default!;
    public DbSet<Location> Location { get; set; } = default!;
    public DbSet<Message> Message { get; set; } = default!;
    public DbSet<Monthly_subscription> Monthly_subscription { get; set; } = default!;
    public DbSet<Sports_school> Sports_school { get; set; } = default!;
    public DbSet<Training> Training { get; set; } = default!;
    public DbSet<User> User { get; set; } = default!;
    public DbSet<User_at_training> User_at_training { get; set; } = default!;
    public DbSet<User_group> User_group { get; set; } = default!;
    public DbSet<User_in_group> User_in_group { get; set; } = default!;
    public DbSet<User_type> User_type { get; set; } = default!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
}