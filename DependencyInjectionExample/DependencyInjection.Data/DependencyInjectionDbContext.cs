using System.Reflection;
using DependencyInjection.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Data;

public class DependencyInjectionDbContext : DbContext
{
    public DependencyInjectionDbContext(DbContextOptions<DependencyInjectionDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}