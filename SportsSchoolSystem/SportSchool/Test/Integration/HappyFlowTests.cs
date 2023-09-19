using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Public.DTO.v1.v1;
using Xunit.Abstractions;
using Public.DTO.v1.v1.Identity;

namespace Test.Integration;

public class HappyFlowTests : IClassFixture<TestWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly JsonSerializerOptions _serializerOptions;

    public HappyFlowTests(TestWebAppFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions()
        {
            AllowAutoRedirect = false
        });
        _testOutputHelper = testOutputHelper;
        _serializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    private async Task<T?> DtoFromResponse<T>(HttpResponseMessage response)
    {
        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStreamAsync(), _serializerOptions);
    }

    private async Task<HttpResponseMessage> AuthoredRequest(
        HttpMethod method,
        JWTResponse jwt,
        string url,
        JsonContent? dto = null)
    {
        HttpRequestMessage request = new(method, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt.JWT);
        if (dto != null) request.Content = dto;

        return await _client.SendAsync(request);
    }
    
    private async Task<HttpResponseMessage> AuthoredGet(JWTResponse jwt, string url)
    {
        return await AuthoredRequest(HttpMethod.Get, jwt, url);
    }
    
    private async Task<HttpResponseMessage> AuthoredPost(JWTResponse jwt, string url, JsonContent dto)
    {
        return await AuthoredRequest(HttpMethod.Post, jwt, url, dto);
    }
    
    private async Task<HttpResponseMessage> AuthoredPut(JWTResponse jwt, string url, JsonContent dto)
    {
        return await AuthoredRequest(HttpMethod.Put, jwt, url, dto);    
    }
    
    private async Task<HttpResponseMessage> AuthoredDelete(JWTResponse jwt, string url)
    {
        return await AuthoredRequest(HttpMethod.Delete, jwt, url);
    }

    [Fact]
    public async Task TestMain()
    {
        // register
        // create location
        // create competition
        // join competition
        // create excercise
        // create training
        // join training
        // remove training
        // logout
        
        JsonContent dto;
        HttpResponseMessage response;
        // CreatedDTO? created;
        // SuccessDTO? success;
        
        DateTime currentDate = DateTime.Today;
        
        
        dto = JsonContent.Create(new Register()
        {
            Email = "integration_test_user@email.com",
            Password = "Strong.Password.1",
            FirstName = "integration_test_user",
            LastName = "integration_test_user_lastname"
        });
        response = await _client.PostAsync("api/v1/identity/account/Register", dto);
        
        JWTResponse? jwt = await DtoFromResponse<JWTResponse>(response);
        
        Assert.NotNull(jwt);
        Assert.NotNull(jwt.JWT);
        Assert.NotNull(jwt.RefreshToken);
        
        Guid locationId = Guid.NewGuid();
        
        dto = JsonContent.Create(new Location()
        {
            Id = locationId,
            Name = "Kalev",
            Address = "Pirita"
        });
        response = await AuthoredPost(jwt, "api/v1/Competition?api-version=1", dto);

        JWTResponse? locResp = await DtoFromResponse<JWTResponse>(response);
        
        Assert.NotNull(locResp);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        
        Guid compId = Guid.NewGuid();
        dto = JsonContent.Create(new Competition()
        {
            Id = compId,
            Name = "Kalev",
            GroupSize = 0,
            Since = DateTime.Today,
            Until = DateTime.Now,
            LocationId = locationId
        });
        response = await AuthoredPost(jwt, "api/v1/Competition?api-version=1", dto);
        
        Competition? compResp = await DtoFromResponse<Competition>(response);
        
        Assert.NotNull(compResp);
        Assert.Equal(locationId, compResp.LocationId);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        
        
        Guid userId = Guid.NewGuid();
        
        dto = JsonContent.Create(new UserAtCompetition()
        {
            Since = DateTime.Today,
            Until = DateTime.Now,
            AppUserId = userId,
            CompetitionId = compId
        });
        response = await AuthoredPost(jwt, "api/v1/UserAtCompetition?api-version=1", dto);
        
        UserAtCompetition? userAtCompResp = await DtoFromResponse<UserAtCompetition>(response);

        Assert.NotNull(userAtCompResp);
        Assert.Equal(compId, userAtCompResp.CompetitionId);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        
        Guid excerciseId = Guid.NewGuid();
        
        dto = JsonContent.Create(new Excercise()
        {
            Id = excerciseId,
            Name = "Test excercise",
            Duration = 60,
            Level = "hard"
        });
        
        response = await AuthoredPost(jwt, "api/v1/Excercise?api-version=1", dto);
        
        Excercise? excerciseResp = await DtoFromResponse<Excercise>(response);

        Assert.NotNull(excerciseResp);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        
        
        Guid trainingId = Guid.NewGuid();
        
        dto = JsonContent.Create(new Training()
        {
            Id = trainingId,
            Name = "Test excercise",
            Duration = 60,
            LocationId = locationId,
            ExcerciseId = excerciseId
        });
        
        response = await AuthoredPost(jwt, "api/v1/Training?api-version=1", dto);
        
        Training? trainingResp = await DtoFromResponse<Training>(response);

        Assert.NotNull(trainingResp);
        Assert.Equal(excerciseId, trainingResp.ExcerciseId);
        Assert.Equal(locationId, trainingResp.LocationId);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        
        
        
        
        dto = JsonContent.Create(new UserAtTraining()
        {
            Since = DateTime.Today,
            Until = DateTime.Now,
            AppUserId = userId,
            TrainingId = trainingId
        });
        response = await AuthoredPost(jwt, "api/v1/UserAtTraining?api-version=1", dto);
        
        UserAtTraining? userAtTraingResp = await DtoFromResponse<UserAtTraining>(response);

        Assert.NotNull(userAtTraingResp);
        Assert.Equal(userId, userAtTraingResp.AppUserId);
        Assert.Equal(trainingId, userAtTraingResp.TrainingId);
        Assert.NotEqual(currentDate, userAtTraingResp.Until);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        
        //Remove training
        
        response = await AuthoredDelete(jwt, $"api/v1/Training/{trainingId}?api-version=1");
        
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        
        //Check if removed
        
        response = await AuthoredGet(jwt, $"api/v1/Training/{trainingId}?api-version=1");
        
        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
        
        //User logout
        
        dto = JsonContent.Create(jwt.RefreshToken);
        response = await AuthoredPost(jwt, "api/v1/identity/account/Logout", dto);
        
        Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);


    }
}