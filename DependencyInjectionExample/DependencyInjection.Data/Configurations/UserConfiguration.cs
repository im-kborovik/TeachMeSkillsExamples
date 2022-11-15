using DependencyInjection.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DependencyInjection.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(w => w.UserId);

        builder.Property(w => w.Email)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(w => w.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(w => w.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasData(new User
                        {
                            FirstName = "Caroline",
                            LastName = "Little",
                            BirthDate = Convert.ToDateTime("2000-12-05T09:52:21.2520595+02:00"),
                            Email = "Caroline.Little4@yahoo.com",
                            UserId = new Guid("4F656C72-CB86-4009-B42E-3A921A22896F")
                        },
                        new User
                        {
                            FirstName = "Judy",
                            LastName = "Walter",
                            BirthDate = Convert.ToDateTime("1982-03-16T06:23:06.291878+02:00"),
                            Email = "Judy92@yahoo.com",
                            UserId = new Guid("A4DB41DE-B0C2-4D13-98BB-CEE92ED26745")
                        },
                        new User
                        {
                            FirstName = "Paulette",
                            LastName = "Beahan",
                            BirthDate = Convert.ToDateTime("1990-08-28T22:15:36.5362425+03:00"),
                            Email = "Sammy32@gmail.com",
                            UserId = new Guid("338859FD-AC5C-43CC-88C4-132A25211A42")
                        });
    }
}