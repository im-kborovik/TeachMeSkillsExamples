using DependencyInjection.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.EfCoreUserManagement;

public class DependencyInjectionDbContext : DbContext
{
    public DependencyInjectionDbContext()
    {
    }

    public DependencyInjectionDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(q =>
                                  {
                                      q.HasKey(w => w.Email);

                                      q.Property(w => w.Email)
                                       .IsRequired()
                                       .HasMaxLength(100);

                                      q.Property(w => w.FirstName)
                                       .IsRequired()
                                       .HasMaxLength(100);

                                      q.Property(w => w.LastName)
                                       .IsRequired()
                                       .HasMaxLength(100);

                                      q.HasData(new User
                                                {
                                                    FirstName = "Caroline",
                                                    LastName = "Little",
                                                    BirthDate = Convert.ToDateTime("2000-12-05T09:52:21.2520595+02:00"),
                                                    Email = "Caroline.Little4@yahoo.com"
                                                },
                                                new User
                                                {
                                                    FirstName = "Judy",
                                                    LastName = "Walter",
                                                    BirthDate = Convert.ToDateTime("1982-03-16T06:23:06.291878+02:00"),
                                                    Email = "Judy92@yahoo.com"
                                                },
                                                new User
                                                {
                                                    FirstName = "Paulette",
                                                    LastName = "Beahan",
                                                    BirthDate = Convert.ToDateTime("1990-08-28T22:15:36.5362425+03:00"),
                                                    Email = "Sammy32@gmail.com"
                                                });
                                  });
    }
}