using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkingWithEfCore.Database.Entities;

namespace WorkingWithEfCore.Database.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(q => q.AddressId);
        
        builder.HasOne(q => q.User)
               .WithMany(q => q.Addresses)
               .HasForeignKey(q => q.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Address");
    }
}