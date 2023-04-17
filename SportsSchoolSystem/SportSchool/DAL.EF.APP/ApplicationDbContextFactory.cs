using DAL.EF.APP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.EF.APP;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        // does not actually connect to db
        optionsBuilder.UseNpgsql("");
        //Host=localhost:5445;Database=aw-train;Username=postgres;Password=postgres
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}