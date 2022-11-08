using System.Text.Json;
using DependencyInjection.Entities.Users;
using DependencyInjection.Exceptions;
using DependencyInjection.FileUserManagement.Interfaces;
using DependencyInjection.InMemoryUserManagement.Interfaces;

namespace DependencyInjection.FileUserManagement;

internal class FileUserService : IUserService
{
    private readonly IFileManager _fileManager;
    private readonly IFileSystemPathProvider _fileSystemPathProvider;

    public FileUserService(IFileManager fileManager, IFileSystemPathProvider fileSystemPathProvider)
    {
        _fileManager = fileManager;
        _fileSystemPathProvider = fileSystemPathProvider;
    }

    #region IUserService Members

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

    #endregion

    private Task WriteUsers(IEnumerable<User> users)
    {
        return _fileManager.Write(_fileSystemPathProvider.GetUsersPath(),
                                  JsonSerializer.Serialize(users,
                                                           new JsonSerializerOptions
                                                           {
                                                               WriteIndented = true
                                                           }));
    }

    private async Task<List<User>> GetUsersInternal()
    {
        var usersStr = await _fileManager.Read(_fileSystemPathProvider.GetUsersPath());
        return JsonSerializer.Deserialize<List<User>>(usersStr);
    }
}