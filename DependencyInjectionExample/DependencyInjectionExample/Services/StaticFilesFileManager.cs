using System.IO;
using System.Threading.Tasks;
using DependencyInjectionExample.Exceptions;
using DependencyInjectionExample.Services.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class StaticFilesFileManager : IFileManager
    {
        private const string BaseDirectory = "StaticFiles";

        public Task<string> Read(string fileName)
        {
            var path = GetPath(fileName);

            ThrowIfNotExist(path);

            return File.ReadAllTextAsync(path);
        }

        public Task Write(string fileName, string text)
        {
            var path = GetPath(fileName);

            ThrowIfNotExist(path);

            return File.WriteAllTextAsync(path, text);
        }

        private static string GetPath(string fileName) => Path.Combine(Directory.GetCurrentDirectory(), BaseDirectory, fileName);

        private static void ThrowIfNotExist(string path)
        {
            if (File.Exists(path) == false)
            {
                throw new ObjectNotFoundException(Path.GetFileName(path));
            }
        }
    }
}