using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using DependencyInjectionExample.Entities;
using DependencyInjectionExample.Exceptions;
using DependencyInjectionExample.Services.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class InMemoryUserService : IUserService
    {
        private static readonly Dictionary<string, User> Users = new();

        static InMemoryUserService()
        {
            InitUsers();
        }

        public Task<IReadOnlyCollection<User>> GetUsers()
        {
            return Task.FromResult<IReadOnlyCollection<User>>(Users.Values);
        }

        public Task<User> AddUser(string email, string firstName, string lastName, DateTime birthDate)
        {
            if (Users.ContainsKey(email))
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
            Users.Add(email, user);

            return Task.FromResult(user);
        }

        public Task<User> UpdateUser(string email, string firstName, string lastName, DateTime birthDate)
        {
            if (Users.ContainsKey(email) == false)
            {
                throw new ObjectNotFoundException("User");
            }

            var user = Users[email];
            user.FirstName = firstName;
            user.LastName = lastName;
            user.BirthDate = birthDate;

            return Task.FromResult(user);
        }

        public Task DeleteUser(string email)
        {
            var wasRemoved = Users.Remove(email);
            if (wasRemoved == false)
            {
                throw new ObjectNotFoundException("User");
            }

            return Task.CompletedTask;
        }

        private static void InitUsers()
        {
            for (var i = 0; i < 10; i++)
            {
                var faker = new Faker();
                var user = new User
                           {
                               Email = faker.Person.Email,
                               FirstName = faker.Person.FirstName,
                               LastName = faker.Person.LastName,
                               BirthDate = faker.Person.DateOfBirth
                           };
                Users.Add(user.Email, user);
            }
        }
    }
}