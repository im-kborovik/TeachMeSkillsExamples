using DependencyInjection.Entities.Users;

namespace DependencyInjection.InMemoryUserManagement.Interfaces;

public interface IUserService
{
    Task<IReadOnlyCollection<User>> GetUsers();

    Task<User> AddUser(string email, string firstName, string lastName, DateTime birthDate);

    Task<User> UpdateUser(string email, string firstName, string lastName, DateTime birthDate);

    Task DeleteUser(string email);
}