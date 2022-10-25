using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DependencyInjectionExample.Entities;
using DependencyInjectionExample.Exceptions;
using DependencyInjectionExample.Services.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class FileUserService : IUserService
    {
        private const string FileName = "users.json";

        private readonly IFileManager _fileManager;

        public FileUserService(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<IReadOnlyCollection<User>> GetUsers()
        {
            return await GetUsersInternal();
        }

        public async Task<User> AddUser(string email, string firstName, string lastName, DateTime birthDate)
        {
            var users = await GetUsersInternal();
            if (users.Any(q => q.Email == email))
            {
                throw new ObjectExistsException("User");
            }

            var user = new User
                       {
                           FirstName = firstName,
                           LastName = lastName,
                           BirthDate = birthDate,
                           Email = email
                       };
            users.Add(user);

            await WriteUsers(users);

            return user;
        }

        public async Task<User> UpdateUser(string email, string firstName, string lastName, DateTime birthDate)
        {
            var users = await GetUsersInternal();
            var user = users.FirstOrDefault(q => q.Email == email);
            if (user is null)
            {
                throw new ObjectNotFoundException("User");
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.BirthDate = birthDate;

            await WriteUsers(users);

            return user;
        }

        public async Task DeleteUser(string email)
        {
            var users = await GetUsersInternal();
            var user = users.FirstOrDefault(q => q.Email == email);
            if (user is null)
            {
                throw new ObjectNotFoundException("User");
            }

            users.Remove(user);

            await WriteUsers(users);
        }

        private Task WriteUsers(IEnumerable<User> users)
        {
            return _fileManager.Write(FileName, JsonSerializer.Serialize(users, new JsonSerializerOptions
                                                                                {
                                                                                    WriteIndented = true
                                                                                }));
        }

        private async Task<List<User>> GetUsersInternal()
        {
            var usersStr = await _fileManager.Read(FileName);
            return JsonSerializer.Deserialize<List<User>>(usersStr);
        }
    }
}