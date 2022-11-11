using DependencyInjection.InMemoryUserManagement.Interfaces;
using DependencyInjection.WebApiUserManagement.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.WebApiUserManagement.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebApiUserManagement(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<WebApiSettings>(configuration.GetSection(WebApiSettings.SectionName));
        
        services.AddScoped<IUserService, WebApiUserService>();
        return services;
    }
}