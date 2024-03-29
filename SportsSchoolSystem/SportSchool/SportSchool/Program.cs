 using System.Text;
 using Asp.Versioning;
 using Asp.Versioning.ApiExplorer;
 using BLL.App;
 using BLL.Contracts.Base;
 using DAL;
 using DAL.Contracts.App;
 using DAL.EF.APP;
 using DAL.EF.APP.Seeding;
 using Domain.App.Identity;
 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.Options;
 using Microsoft.IdentityModel.Tokens;
 using SportSchool;
 using Swashbuckle.AspNetCore.SwaggerGen;

 var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));



//register our UOW with scoped lifecycle

 builder.Services.AddScoped<IAppUOW, AppUOW>();
 builder.Services.AddScoped<IAppBLL, AppBLL>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<AppUser, AppRole>(
        options => options.SignIn.RequireConfirmedAccount = false
        )
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    //.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services
    .AddAuthentication()
    .AddCookie(options => { options.SlidingExpiration = true; })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = builder.Configuration.GetValue<string>("JWT:Issuer")!,
            ValidAudience = builder.Configuration.GetValue<string>("JWT:Audience")!,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWT:Key")!)),
            ClockSkew = TimeSpan.Zero,
        };
    });
 
 
builder.Services.AddControllersWithViews();

 
 builder.Services.AddCors(options =>
     {
         options.AddPolicy("CorsAllowAll", policy =>
         {
             policy.AllowAnyHeader();
             policy.AllowAnyMethod();
             policy.AllowAnyOrigin();
         });
     }
 );
 
 // add automapper configurations

 builder.Services.AddAutoMapper(
     typeof(BLL.App.AutoMapperConfig),
     typeof(Public.DTO.v1.AutoMapperConfig)
 );


 var apiVersioningBuilder = builder.Services.AddApiVersioning(options =>
 {
     options.ReportApiVersions = false;
     // in case of no explicit version
     options.DefaultApiVersion = new ApiVersion(1, 0);
 });

 apiVersioningBuilder.AddApiExplorer(options =>
     {
         options.GroupNameFormat = "'v'VVV";

         options.SubstituteApiVersionInUrl = false;
     }

 );
 
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
 builder.Services.AddSwaggerGen();
 
 
 //To enable UTC timezones in postgres
 AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
 
 
 
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

 // is used to get rid of postgres exception about using the timezones
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
 
 
 
 
app.UseHttpsRedirection();
app.UseStaticFiles();

 
 
 
 
app.UseRouting();
 
 
app.UseCors("CorsAllowAll");
 
app.UseAuthorization();


 app.UseSwagger();
 app.UseSwaggerUI(options =>
     {
         var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
     foreach (var description in provider.ApiVersionDescriptions)
     {
         options.SwaggerEndpoint(
             $"/swagger/{description.GroupName}/swagger.json",
             description.GroupName
             );
     }
 }
 );
 

 app.MapControllerRoute(
     name: "default",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

 
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
    if (configuration.GetValue<bool>("DataInit:DropDataBase"))
    {
        logger.LogWarning("Dropping database!");
        AppDataInit.DropDatabase(context);
    }
    
    //migartion
    if (configuration.GetValue<bool>("DataInit:MigrateDatabase"))
    {
        logger.LogInformation("Migrating database!");
        AppDataInit.MigrateDatabase(context);
    }
    
    //seed identity
    if (configuration.GetValue<bool>("DataInit:SeedIdentity"))
    {
        logger.LogWarning("Seeding identity!");
        AppDataInit.SeedIdentity(userManager, roleManager);
    }
    
    //seed application data
    if (configuration.GetValue<bool>("DataInit:SeedData"))
    {
        logger.LogWarning("Seed app data!");
        AppDataInit.SeedAppData(context);
    }
    
    
    
}
 public partial class Program { }