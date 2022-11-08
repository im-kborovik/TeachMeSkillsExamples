using DependencyInjection.InMemoryUserManagement.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InMemoryUserManagement.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInMemoryUserManagement(this IServiceCollection services)
    {
        services.AddScoped<IUserService, InMemoryUserService>();
        return services;
    }
}