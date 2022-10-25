using System.Threading.Tasks;
using Module23_24.Ado_Net.Interfaces;

namespace Module23_24.Ado_Net
{
    public class AdoDotNetTableManager : DbBase, ITableManager
    {
        private readonly IDatabaseService _databaseService;

        public AdoDotNetTableManager(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        private bool HasDatabase => _databaseService.EnsureDatabase();

        public async Task CreateUsersTableWithData()
        {
            if (!HasDatabase)
            {
                return;
            }

            const string checkUsersTable = @"select count(*) from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Users';";
            var hasUsersTable = await MakeInCommand(async command =>
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
                          Age int null
                );";

            await MakeInCommand(command =>
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
                values('Ivan', 'Ivanov', N'ivaт@ivanov.com', null),
                      ('Petr', 'Petrov', N'petr@petrov.com', 35),
                      ('Irina', 'Ptushkina', N'irina@ptushkina.com', 32);";

            return MakeInCommand(command =>
                                 {
                                     command.CommandText = sql;
                                     return command.ExecuteNonQueryAsync();
                                 });
        }
    }
}