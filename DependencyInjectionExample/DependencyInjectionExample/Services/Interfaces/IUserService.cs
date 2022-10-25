using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DependencyInjectionExample.Entities;

namespace DependencyInjectionExample.Services.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<User>> GetUsers();

        Task<User> AddUser(string email, string firstName, string lastName, DateTime birthDate);

        Task<User> UpdateUser(string email, string firstName, string lastName, DateTime birthDate);

        Task DeleteUser(string email);
    }
}