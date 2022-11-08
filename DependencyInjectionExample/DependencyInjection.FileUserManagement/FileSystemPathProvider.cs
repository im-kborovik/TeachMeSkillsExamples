using DependencyInjection.FileUserManagement.Interfaces;

namespace DependencyInjection.FileUserManagement;

internal class FileSystemPathProvider : IFileSystemPathProvider
{
    public string GetUsersPath()
    {
        return Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", "users.json");
    }
}