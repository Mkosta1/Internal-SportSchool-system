using DAL.EF.APP;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Test;

public class TestWebAppFactory<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureServices(services =>
        {
            ServiceDescriptor? ctxSd = services.SingleOrDefault(sd =>
                sd.ServiceType == typeof(DbContextOptions<ApplicationDbContext>)
            );

            if (ctxSd != null)
            {
                services.Remove(ctxSd);
            }

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseInMemoryDatabase("IntegrationTestsDb")
            );

            ServiceProvider sp = services.BuildServiceProvider();
            using (IServiceScope scope = sp.CreateScope())
            {
                IServiceProvider scopedServices = scope.ServiceProvider;
                ApplicationDbContext ctx = scopedServices.GetRequiredService<ApplicationDbContext>();

                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                ctx.Location.Add(new Location()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "Pärnu",
                    Address = "Lootsi"
                });
                ctx.Excercise.Add(new Excercise()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "Body",
                    Duration = 60,
                    Level = "Hard"
                });
                ctx.SaveChanges();
            }
        });
    }
}
