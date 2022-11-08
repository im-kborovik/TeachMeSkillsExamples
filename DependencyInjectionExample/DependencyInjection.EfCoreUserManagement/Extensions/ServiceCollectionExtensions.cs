using DependencyInjection.InMemoryUserManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.EfCoreUserManagement.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEfCoreUserManagement(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DependencyInjectionDbContext>(options =>
                                                            {
                                                                options.UseSqlServer(connectionString);
                                                            });
        services.AddScoped<IUserService, EfCoreUserService>();

        return services;
    }
}