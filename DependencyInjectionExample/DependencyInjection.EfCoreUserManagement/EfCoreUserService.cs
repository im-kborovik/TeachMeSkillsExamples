using DependencyInjection.Entities.Users;
using DependencyInjection.Exceptions;
using DependencyInjection.InMemoryUserManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.EfCoreUserManagement;

public class EfCoreUserService : IUserService
{
    private readonly DependencyInjectionDbContext _context;

    public EfCoreUserService(DependencyInjectionDbContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyCollection<User>> GetUsers()
    {
        return await _context.Users.AsNoTracking().ToArrayAsync();
    }

    public async Task<User> AddUser(string email, string firstName, string lastName, DateTime birthDate)
    {
        if (await _context.Users.AnyAsync(q => q.Email == email))
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
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateUser(string email, string firstName, string lastName, DateTime birthDate)
    {
        var user = await _context.Users.SingleOrDefaultAsync(q => q.Email == email);
        if (user is null)
        {
            throw new ObjectNotFoundException("User");
        }

        user.FirstName = firstName;
        user.LastName = lastName;
        user.BirthDate = birthDate;

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task DeleteUser(string email)
    {
        var user = await _context.Users.SingleOrDefaultAsync(q => q.Email == email);
        if (user is null)
        {
            throw new ObjectNotFoundException("User");
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}