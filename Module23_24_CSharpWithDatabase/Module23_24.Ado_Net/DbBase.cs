using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Module23_24.Shared;

namespace Module23_24.Ado_Net
{
    public abstract class DbBase : IDisposable
    {
        protected readonly SqlConnection Connection;

        protected virtual string ConnectionString => ConnectionStrings.SqlDatabaseConnectionDefault;

        protected DbBase()
        {
            Connection = new SqlConnection(ConnectionString);
        }

        protected async Task MakeInCommand(Func<SqlCommand, Task> func)
        {
            await Connection.OpenAsync();

            var command = new SqlCommand
                          {
                              Connection = Connection
                          };

            await func.Invoke(command);

            await Connection.CloseAsync();
        }

        protected async Task<T> MakeInCommand<T>(Func<SqlCommand, Task<T>> func)
        {
            await Connection.OpenAsync();

            var command = new SqlCommand
                          {
                              Connection = Connection
                          };
            var result = await func.Invoke(command);

            await Connection.CloseAsync();

            return result;
        }

        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}