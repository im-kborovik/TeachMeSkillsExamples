using Microsoft.EntityFrameworkCore;
using WorkingWithEfCore.Database.Configurations;
using WorkingWithEfCore.Database.Entities;

namespace WorkingWithEfCore.Database;

public class MyDbContext : DbContext
{
    public MyDbContext()
    {
        
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (optionsBuilder.IsConfigured == false)
        {
            const string connectionString = "Server=localhost;Database=WorkingWithEfCore;Trusted_Connection=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
    }
}