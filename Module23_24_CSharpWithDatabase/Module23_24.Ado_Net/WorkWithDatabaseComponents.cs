using System.Threading.Tasks;
using Module23_24.Shared;

namespace Module23_24.Ado_Net
{
    public class WorkWithDatabaseComponents : DbBase
    {
        private bool _hasDatabase;

        public WorkWithDatabaseComponents(bool userMaster = false) : base(userMaster)
        {
            MakeInCommand(async command =>
                          {
                              var checkDb = @$"select count(*) from master.sys.databases where name = '{ConnectionStrings.DatabaseName}';";

                              command.CommandText = checkDb;

                              var checkDbResult = await command.ExecuteScalarAsync();
                              _hasDatabase = (int)checkDbResult! != 0;
                          })
                .GetAwaiter()
                .GetResult();
        }

        public Task CreateDatabase()
        {
            if (_hasDatabase)
            {
                return Task.CompletedTask;
            }

            const string sql = "create database AdoDotNetExample;";

            return MakeInCommand(command =>
                                 {
                                     command.CommandText = sql;
                                     return command.ExecuteNonQueryAsync();
                                 });
        }

        public async Task CreateUsersTableWithData()
        {
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

        public Task DropDatabase()
        {
            var sql = @$"
                use master;
                alter database [{ConnectionStrings.DatabaseName}] set single_user with rollback immediate;
                drop database [{ConnectionStrings.DatabaseName}];
            ";
            return MakeInCommand(command =>
                                 {
                                     command.CommandText = sql;
                                     return command.ExecuteNonQueryAsync();
                                 });
        }

        //
        // public Task<User[]> GetUsers()
        // {
        //     const string sql = "select * from Users";
        //
        //     MakeInConnection(async connection =>
        //                      {
        //                          var command = new SqlCommand(sql, connection);
        //                          var sqlDataReader = await command.ExecuteReaderAsync();
        //                      })
        // }

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