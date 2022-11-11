using System.Net.Http.Json;
using DependencyInjection.Entities.Users;
using DependencyInjection.InMemoryUserManagement.Interfaces;
using DependencyInjection.WebApiUserManagement.Settings;
using Microsoft.Extensions.Options;

namespace DependencyInjection.WebApiUserManagement;

public class WebApiUserService : IUserService
{
    private readonly IHttpClientFactory _factory;
    private readonly WebApiSettings _webApiSettings;

    public WebApiUserService(IHttpClientFactory factory, IOptionsSnapshot<WebApiSettings> webApiSettings)
    {
        _factory = factory;
        _webApiSettings = webApiSettings.Value;
    }
    
    public async Task<IReadOnlyCollection<User>> GetUsers()
    {
        var httpClient = CreateClient();
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, _webApiSettings.GetUsers);
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        return await httpResponseMessage.Content.ReadFromJsonAsync<IReadOnlyCollection<User>>();
    }

    public async Task<User> AddUser(string email, string firstName, string lastName, DateTime birthDate)
    {
        var httpClient = CreateClient();
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _webApiSettings.AddUser + $"/{email}");
        httpRequestMessage.Content = JsonContent.Create(new
                                                        {
                                                            FirstName = firstName,
                                                            LastName = lastName,
                                                            BirthDate = birthDate
                                                        });
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        return await httpResponseMessage.Content.ReadFromJsonAsync<User>();
    }

    public async Task<User> UpdateUser(string email, string firstName, string lastName, DateTime birthDate)
    {
        var httpClient = CreateClient();
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, _webApiSettings.UpdateUser + $"/{email}");
        httpRequestMessage.Content = JsonContent.Create(new
                                                        {
                                                            FirstName = firstName,
                                                            LastName = lastName,
                                                            BirthDate = birthDate
                                                        });
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        return await httpResponseMessage.Content.ReadFromJsonAsync<User>();
    }

    public Task DeleteUser(string email)
    {
        var httpClient = CreateClient();
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, _webApiSettings.DeleteUser + $"/{email}");
        return httpClient.SendAsync(httpRequestMessage);
    }

    private HttpClient CreateClient()
    {
        var httpClient = _factory.CreateClient();
        httpClient.BaseAddress = new Uri(_webApiSettings.BaseAddress);
        return httpClient;
    }
}