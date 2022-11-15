using System.Reflection;
using DependencyInjection.BusinessLayer.Interfaces;
using DependencyInjection.BusinessLayer.Services.Users;
using DependencyInjection.Data.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.BusinessLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services, string connectionStrig)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddDatabase(connectionStrig);
        services.AddAutoMapper(Assembly.GetCallingAssembly(),
                               Assembly.GetExecutingAssembly());

        return services;
    }
}