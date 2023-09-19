using System.Runtime.InteropServices.JavaScript;
using Domain;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.APP.Seeding;

public static class AppDataInit
{
    
    private static Guid adminId = Guid.Parse("8dbfed7f-81f1-4307-9bf8-17e0167a95f6");
    
    private static Guid userGroupId = new Guid();
    
    public static void MigrateDatabase(ApplicationDbContext context)
    {
        context.Database.Migrate();
    }
    
    public static void DropDatabase(ApplicationDbContext context)
    {
        context.Database.EnsureDeleted();
    }
    
    public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        (Guid id, string email, string pwd) userData = (adminId, "admin@app.com", "Foo.bar.1");
        var user = userManager.FindByEmailAsync(userData.email).Result;
        if (user == null)
        {
            user = new AppUser()
            {
                Id = userData.id,
                Email = userData.email,
                UserName = userData.email,
                FirstName = "Admin",
                LastName = "App",
                EmailConfirmed = true,

            };
            var result = userManager.CreateAsync(user, userData.pwd).Result;
            if (!result.Succeeded)
            {
                throw new ApplicationException("Cannot seed users");
            }
            
        }
    }
    
    public static void SeedAppData(ApplicationDbContext context)
    {

        context.SaveChanges();

    }
    

    
    
    

    
}