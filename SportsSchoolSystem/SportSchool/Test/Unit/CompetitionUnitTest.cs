using AutoMapper;
using BLL.App;
using BLL.App.Mappers;
using BLL.App.Services;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.EF.APP;
using Domain;
using Domain.App.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SportSchool.Controllers;
using Xunit.Abstractions;

namespace Test.Unit;

public class CompetitionUnitTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ApplicationDbContext _ctx;
    private readonly CompetitionService _service;
    private readonly IMapper<BLL.DTO.Competition,Domain.Competition> _mapper;
    private readonly IMapper _map;
    
    private Guid _competitionId = Guid.NewGuid();
    private Guid _locationId = Guid.NewGuid();
    private Guid _user1Id = Guid.NewGuid();
    
    public CompetitionUnitTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        _ctx = new(optionsBuilder.Options);
    
        _ctx.Database.EnsureDeleted();
        _ctx.Database.EnsureCreated();
    
        IAppUOW uow = new AppUOW(_ctx);
        
        Mock<ICompetitionService> mockRepo = new Mock<ICompetitionService>();
        
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperConfig());
        });
        var mapper = mockMapper.CreateMapper();
        
        _mapper = new CompetitionMapper(mapper);
        
        _service = new CompetitionService(uow, _mapper);
        
    }
    
    private async Task SeedDataAsync()
    {
        
        AppUser u1 = new()
        {
            FirstName = "test",
            LastName = "user"
        };
        _ctx.Users.AddRange(u1);
        _user1Id = u1.Id;
        
        
        _ctx.Location.Add(new Location()
        {
            Id = _locationId,
            Name = "Kalev",
            Address = "Pirita"
        });
    
        _ctx.Competition.Add(new Competition()
        {
            Id = _competitionId,
            Name = "EMV",
            GroupSize = 4,
            Since = DateTime.Now,
            Until = DateTime.Now,
            LocationId = _locationId
        });
    
       await _ctx.SaveChangesAsync();
    }
    
    
    //Get seeded data
    [Fact]
    public async Task TestAllAsync()
    {
        //Seed data
    
        await SeedDataAsync();
        
        var id = _ctx.Competition.First().Id;
    
        List<BLL.DTO.Competition> compId = (await _service.AllAsync()).ToList();
        Assert.NotEmpty(compId);
        Assert.Single(compId);

        BLL.DTO.Competition item = compId.First();
        Assert.Equal(_competitionId, item.Id);
        Assert.Equal("EMV", item.Name);
        Assert.Equal(4, item.GroupSize);
        Assert.Equal(_locationId, item.LocationId);
    }
    
    //insert data
    //get data
    //delete data
    
    //Use add service and check if it was added
    [Fact]
    public async Task TestAdd()
    {
        Guid newCompId = Guid.NewGuid();
        
        BLL.DTO.Competition c = new BLL.DTO.Competition()
        {
            Id = newCompId,
            Name = "testAdd",
            GroupSize = 2,
            Since = DateTime.Now,
            Until = DateTime.Now,
            LocationId = _locationId
        };
    
        var id =  _service.Add(c);
        await _ctx.SaveChangesAsync();
        
        BLL.DTO.Competition getComp = await _service.FindAsync(id.Id);
        
        Assert.Equal(_locationId, getComp!.LocationId);
        Assert.Equal("testAdd", getComp.Name);
        Assert.Equal(2, getComp.GroupSize);
    
    }
    
    
    //Testing delete service
    [Fact]
    public async Task TestRemoveAsync()
    {
        //Checking seeded data
        
        await SeedDataAsync();
        
        var compId = _ctx.Competition.First().Id;
    
        BLL.DTO.Competition compData = await _service.FindAsync(compId);
        
        Assert.NotNull(compData);
        Assert.Equal(_competitionId, compData.Id);
        Assert.Equal("EMV", compData.Name);
        Assert.Equal(4, compData.GroupSize);
        Assert.Equal(_locationId, compData.LocationId);
        
        //delete seeded table

        await _service.RemoveAsync(compId, _user1Id);

        await _ctx.SaveChangesAsync();
        
        BLL.DTO.Competition getRemovedComp = await _service.FindAsync(compId);
            
        Assert.Null(getRemovedComp);
        
    }
    
    
}
    