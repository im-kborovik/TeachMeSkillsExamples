using System.Threading.Tasks;
using Module23_24.Ado_Net.Interfaces;
using Module23_24.Shared;

namespace Module23_24.Ado_Net
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IMasterConnectionProvider _connectionProvider;
        private static readonly object Locker = new();
        private static bool _isCreated;

        public DatabaseService(IMasterConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public bool EnsureDatabase()
        {
            if (_isCreated)
            {
                return _isCreated;
            }

            lock (Locker)
            {
                if (_isCreated)
                {
                    return _isCreated;
                }

                var hasDatabase = _connectionProvider
                                  .MakeInCommand(async command =>
                                                 {
                                                     var checkDb =
                                                         @$"select count(*) from master.sys.databases where name = '{ConnectionStrings.DatabaseName}';";

                                                     command.CommandText = checkDb;

                                                     var checkDbResult = await command.ExecuteScalarAsync();

                                                     return (int)checkDbResult! != 0;
                                                 })
                                  .GetAwaiter()
                                  .GetResult();

                if (hasDatabase)
                {
                    _isCreated = true;

                    return _isCreated;
                }

                CreateDatabase();

                _isCreated = true;
            }

            return _isCreated;
        }


        public async Task DropDatabase()
        {
            var sql = @$"
                alter database [{ConnectionStrings.DatabaseName}] set single_user with rollback immediate;
                drop database [{ConnectionStrings.DatabaseName}];
            ";
            await _connectionProvider.MakeInCommand(command =>
                                                    {
                                                        command.CommandText = sql;
                                                        return command.ExecuteNonQueryAsync();
                                                    });

            _isCreated = false;
        }

        private void CreateDatabase()
        {
            const string sql = "create database AdoDotNetExample;";

            _connectionProvider.MakeInCommand(command =>
                                              {
                                                  command.CommandText = sql;
                                                  return command.ExecuteNonQueryAsync();
                                              })
                               .GetAwaiter()
                               .GetResult();
        }
    }
}