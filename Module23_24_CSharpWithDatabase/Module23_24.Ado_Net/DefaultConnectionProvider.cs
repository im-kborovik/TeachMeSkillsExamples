using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Module23_24.Ado_Net.Interfaces;

namespace Module23_24.Ado_Net
{
    public class DefaultConnectionProvider : IDefaultConnectionProvider
    {
        protected readonly IConfiguration Configuration;
        private readonly SqlConnection _connection;

        protected virtual string ConnectionString => Configuration.GetConnectionString("DefaultConnection");

        public DefaultConnectionProvider(IConfiguration configuration)
        {
            Configuration = configuration;
            _connection = new SqlConnection(ConnectionString);
        }

        public async Task MakeInCommand(Func<SqlCommand, Task> func)
        {
            await _connection.OpenAsync();

            var command = new SqlCommand
                          {
                              Connection = _connection
                          };

            await func.Invoke(command);

            await _connection.CloseAsync();
        }

        public async Task<T> MakeInCommand<T>(Func<SqlCommand, Task<T>> func)
        {
            await _connection.OpenAsync();

            var command = new SqlCommand
                          {
                              Connection = _connection
                          };
            var result = await func.Invoke(command);

            await _connection.CloseAsync();

            return result;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}