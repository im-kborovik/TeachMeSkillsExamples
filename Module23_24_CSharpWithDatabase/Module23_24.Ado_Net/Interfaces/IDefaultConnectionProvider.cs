using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Module23_24.Ado_Net.Interfaces
{
    public interface IDefaultConnectionProvider : IDisposable
    {
        Task MakeInCommand(Func<SqlCommand, Task> func);

        Task<T> MakeInCommand<T>(Func<SqlCommand, Task<T>> func);
    }
}