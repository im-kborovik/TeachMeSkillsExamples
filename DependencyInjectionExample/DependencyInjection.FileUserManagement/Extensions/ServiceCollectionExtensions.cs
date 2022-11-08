using DependencyInjection.FileUserManagement.Interfaces;
using DependencyInjection.InMemoryUserManagement.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.FileUserManagement.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserManagementByFile(this IServiceCollection services)
    {
        services.AddSingleton<IFileManager, StaticFilesFileManager>();
        services.AddSingleton<IFileSystemPathProvider, FileSystemPathProvider>();

        services.AddScoped<IUserService, FileUserService>();

        return services;
    }
}