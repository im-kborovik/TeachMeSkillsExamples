// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkingWithEfCore.Database;

#nullable disable

namespace WorkingWithEfCore.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221104180941_AddCompanyContactAndChangeUser")]
    partial class AddCompanyContactAndChangeUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WorkingWithEfCore.Database.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("WorkingWithEfCore.Database.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WorkingWithEfCore.Database.Entities.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ContactId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("WorkingWithEfCore.Database.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearsUntilRetirement")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WorkingWithEfCore.Database.Entities.Address", b =>
                {
                    b.HasOne("WorkingWithEfCore.Database.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkingWithEfCore.Database.Entities.Contact", b =>
                {
                    b.HasOne("WorkingWithEfCore.Database.Entities.User", "User")
                        .WithOne("Contact")
                        .HasForeignKey("WorkingWithEfCore.Database.Entities.Contact", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkingWithEfCore.Database.Entities.User", b =>
                {
                    b.HasOne("WorkingWithEfCore.Database.Entities.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WorkingWithEfCore.Database.Entities.Company", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WorkingWithEfCore.Database.Entities.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
