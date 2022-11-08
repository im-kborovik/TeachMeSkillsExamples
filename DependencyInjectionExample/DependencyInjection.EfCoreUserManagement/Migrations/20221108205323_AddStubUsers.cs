using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DependencyInjection.EfCoreUserManagement.Migrations
{
    public partial class AddStubUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "BirthDate", "FirstName", "LastName" },
                values: new object[] { "Caroline.Little4@yahoo.com", new DateTime(2000, 12, 5, 10, 52, 21, 252, DateTimeKind.Local).AddTicks(595), "Caroline", "Little" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "BirthDate", "FirstName", "LastName" },
                values: new object[] { "Judy92@yahoo.com", new DateTime(1982, 3, 16, 7, 23, 6, 291, DateTimeKind.Local).AddTicks(8780), "Judy", "Walter" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "BirthDate", "FirstName", "LastName" },
                values: new object[] { "Sammy32@gmail.com", new DateTime(1990, 8, 28, 22, 15, 36, 536, DateTimeKind.Local).AddTicks(2425), "Paulette", "Beahan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Caroline.Little4@yahoo.com");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Judy92@yahoo.com");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Sammy32@gmail.com");
        }
    }
}
