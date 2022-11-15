using DependencyInjection.Data.Repositories.Interfaces;
using DependencyInjection.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Data.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DependencyInjectionDbContext _context;

    public UserRepository(DependencyInjectionDbContext context)
    {
        _context = context;
    }

    public IQueryable<User> GetAll()
    {
        return _context.Users.AsQueryable();
    }

    public async Task<User> GetById(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public Task Add(User entity)
    {
        return _context.Users.AddAsync(entity).AsTask();
    }

    public void Update(Guid id, User entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task Delete(Guid id)
    {
        var user = await GetById(id);

        if (user is null)
        {
            return;
        }
        
        _context.Remove(user);
    }

    public Task Save()
    {
        return _context.SaveChangesAsync();
    }
}