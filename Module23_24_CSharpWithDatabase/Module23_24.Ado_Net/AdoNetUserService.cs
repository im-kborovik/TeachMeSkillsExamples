using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Module23_24.Ado_Net.Interfaces;
using Module23_24.Shared.Entities;
using Module23_24.Shared.Interfaces;
using Module23_24.Shared.Models;

namespace Module23_24.Ado_Net
{
    public class AdoNetUserService : IUserService
    {
        private readonly IDefaultConnectionProvider _connectionProvider;

        public AdoNetUserService(IDefaultConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<IReadOnlyCollection<UserModel>> GetUsers()
        {
            const string sql = "select * from Users";
            var users = await _connectionProvider
                            .MakeInCommand(async command =>
                                           {
                                               command.CommandText = sql;

                                               var dataReader = await command.ExecuteReaderAsync();
                                               var users = new List<User>();

                                               while (await dataReader.ReadAsync())
                                               {
                                                   var user = new User
                                                              {
                                                                  UserId = await dataReader.GetFieldValueAsync<int>(nameof(User.UserId)),
                                                                  Email = await dataReader.GetFieldValueAsync<string>(nameof(User.Email)),
                                                                  FirstName = await dataReader.GetFieldValueAsync<string>(nameof(User.FirstName)),
                                                                  LastName = await dataReader.GetFieldValueAsync<string>(nameof(User.LastName)),
                                                                  BirthDate = await dataReader.IsDBNullAsync(nameof(User.BirthDate))
                                                                                  ? null
                                                                                  : await dataReader.GetFieldValueAsync<DateTime?>(nameof(User.BirthDate))
                                                              };
                                                   users.Add(user);
                                               }

                                               return users;
                                           });
            return users.Select(q => new UserModel
                                     {
                                         UserId = q.UserId,
                                         FirstName = q.FirstName,
                                         LastName = q.LastName,
                                         Email = q.Email,
                                         BirthDate = q.BirthDate
                                     })
                        .ToArray();
        }

        public Task<UserModel> CreateUser(UserModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserModel> UpdateUser(UserModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}