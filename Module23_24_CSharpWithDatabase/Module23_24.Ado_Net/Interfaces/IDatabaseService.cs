using System.Threading.Tasks;

namespace Module23_24.Ado_Net.Interfaces
{
    public interface IDatabaseService
    {
        bool EnsureDatabase();

        Task DropDatabase();
    }
}