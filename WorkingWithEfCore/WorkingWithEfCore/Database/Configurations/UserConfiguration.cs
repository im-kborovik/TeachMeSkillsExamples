using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkingWithEfCore.Database.Entities;

namespace WorkingWithEfCore.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(q => q.UserId);
        
        builder.HasOne(q => q.Company)
               .WithMany(q => q.Users)
               .HasForeignKey(q => q.CompanyId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(q => q.Contact)
               .WithOne(q => q.User)
               .HasForeignKey<Contact>(q => q.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}