using DependencyInjection.Data.Repositories;
using DependencyInjection.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DependencyInjectionDbContext>(options =>
                                                            {
                                                                options.UseSqlServer(connectionString);
                                                            });
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}