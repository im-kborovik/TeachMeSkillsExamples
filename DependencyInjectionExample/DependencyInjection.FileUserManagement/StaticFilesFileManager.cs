using DependencyInjection.Exceptions;
using DependencyInjection.FileUserManagement.Interfaces;

namespace DependencyInjection.FileUserManagement;

internal class StaticFilesFileManager : IFileManager
{
    public Task<string> Read(string path)
    {
        ThrowIfNotExist(path);

        return File.ReadAllTextAsync(path);
    }

    public Task Write(string path, string text)
    {
        ThrowIfNotExist(path);

        return File.WriteAllTextAsync(path, text);
    }

    private static void ThrowIfNotExist(string path)
    {
        if (File.Exists(path) == false)
        {
            throw new ObjectNotFoundException(Path.GetFileName(path));
        }
    }
}