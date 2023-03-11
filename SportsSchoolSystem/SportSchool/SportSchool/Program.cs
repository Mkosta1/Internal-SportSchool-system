 using DAL;
using DAL.EF.APP;
 using DAL.EF.APP.Seeding;
 using Domain.App.Identity;
 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<AppUser, AppRole>(
        options => options.SignIn.RequireConfirmedAccount = false
        )
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    //.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//====================================
var app = builder.Build();
//====================================
//setup for the webserver
//setup database things
SetUpAppData(app, app.Environment, app.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


static void SetUpAppData(IApplicationBuilder app, IWebHostEnvironment environment, IConfiguration configuration)
{

    using var serviceScope = app.ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope();
    using var context = serviceScope.ServiceProvider
        .GetService<ApplicationDbContext>();
    
    if (context == null)
    {
        throw new Exception("Service problem, no db.");
    }

    using var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
    using var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<AppRole>>();
    
    if (userManager == null || roleManager == null)
    {
        throw new Exception("Problem in services. Can't initialize usermanager or rolemanager.");
    }
    
    var logger = serviceScope.ServiceProvider.GetService<ILogger<IApplicationBuilder>>();

    if (logger == null)
    {
        throw new Exception("Service problem with logger.");
    }

    if (context.Database.ProviderName!.Contains("InMemory"))
    {
        return;
    }
    //TODO: wait for db connection
    
    //database drop
    if (configuration.GetValue<bool>("DataInit: DropDataBase"))
    {
        logger.LogWarning("Dropping database!");
        AppDataInit.DropDatabase(context);
    }
    
    //migartion
    if (configuration.GetValue<bool>("DataInit: MigrateDatabase"))
    {
        logger.LogInformation("Migrating database!");
        AppDataInit.MigrateDatabase(context);
    }
    
    //seed identity
    if (configuration.GetValue<bool>("DataInit: SeedIdentity"))
    {
        logger.LogWarning("Seeding identity!");
        AppDataInit.SeedIdentity(userManager, roleManager);
    }
    
    //seed application data
    if (configuration.GetValue<bool>("DataInit: SeedData"))
    {
        logger.LogWarning("Seed app data!");
        AppDataInit.SeedAppData(context);
    }
    
    
    
}