using System.Threading.Tasks;
using Module23_24.Ado_Net.Interfaces;

namespace Module23_24.Ado_Net
{
    public class AdoDotNetTableManager : ITableManager
    {
        private readonly IDatabaseService _databaseService;
        private readonly IDefaultConnectionProvider _connectionProvider;

        public AdoDotNetTableManager(IDatabaseService databaseService, IDefaultConnectionProvider connectionProvider)
        {
            _databaseService = databaseService;
            _connectionProvider = connectionProvider;
        }

        private bool HasDatabase => _databaseService.EnsureDatabase();

        public async Task CreateUsersTableWithData()
        {
            if (!HasDatabase)
            {
                return;
            }

            const string checkUsersTable = @"select count(*) from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Users';";
            var hasUsersTable = await _connectionProvider.MakeInCommand(async command =>
                                                                        {
                                                                            command.CommandText = checkUsersTable;

                                                                            var checkUsersTableResult = await command.ExecuteScalarAsync();
                                                                            return (int)checkUsersTableResult! != 0;
                                                                        });
            if (hasUsersTable)
            {
                return;
            }

            const string sql = @"
                create table Users(
                          UserId int primary key not null identity(1, 1),
                          FirstName nvarchar(100) not null,
                          LastName nvarchar(100) not null,
                          Email nvarchar(100) not null,
                          BirthDate datetime null
                );";

            await _connectionProvider.MakeInCommand(command =>
                                                    {
                                                        command.CommandText = sql;
                                                        return command.ExecuteNonQueryAsync();
                                                    });

            await FillUsersTable();
        }

        private Task FillUsersTable()
        {
            const string sql = @"
                insert into Users
                values('Ivan', 'Ivanov', N'ivan@ivanov.com', null),
                      ('Petr', 'Petrov', N'petr@petrov.com', '1995-09-28'),
                      ('Irina', 'Ptushkina', N'irina@ptushkina.com', '1988-06-09');";

            return _connectionProvider.MakeInCommand(command =>
                                                     {
                                                         command.CommandText = sql;
                                                         return command.ExecuteNonQueryAsync();
                                                     });
        }
    }
}