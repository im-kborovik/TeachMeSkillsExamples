using System.Threading.Tasks;

namespace DependencyInjectionExample.Services.Interfaces
{
    public interface IFileManager
    {
        Task<string> Read(string fileName);

        Task Write(string fileName, string text);
    }
}