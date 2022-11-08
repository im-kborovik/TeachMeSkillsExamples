﻿// <auto-generated />
using System;
using DependencyInjection.EfCoreUserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DependencyInjection.EfCoreUserManagement.Migrations
{
    [DbContext(typeof(DependencyInjectionDbContext))]
    partial class DependencyInjectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DependencyInjection.Entities.Users.User", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Email");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Email = "Caroline.Little4@yahoo.com",
                            BirthDate = new DateTime(2000, 12, 5, 10, 52, 21, 252, DateTimeKind.Local).AddTicks(595),
                            FirstName = "Caroline",
                            LastName = "Little"
                        },
                        new
                        {
                            Email = "Judy92@yahoo.com",
                            BirthDate = new DateTime(1982, 3, 16, 7, 23, 6, 291, DateTimeKind.Local).AddTicks(8780),
                            FirstName = "Judy",
                            LastName = "Walter"
                        },
                        new
                        {
                            Email = "Sammy32@gmail.com",
                            BirthDate = new DateTime(1990, 8, 28, 22, 15, 36, 536, DateTimeKind.Local).AddTicks(2425),
                            FirstName = "Paulette",
                            LastName = "Beahan"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
