using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DependencyInjection.EfCoreUserManagement.Migrations
{
    public partial class ChangePKforUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("338859fd-ac5c-43cc-88c4-132a25211a42"), new DateTime(1990, 8, 28, 22, 15, 36, 536, DateTimeKind.Local).AddTicks(2425), "Sammy32@gmail.com", "Paulette", "Beahan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("4f656c72-cb86-4009-b42e-3a921a22896f"), new DateTime(2000, 12, 5, 9, 52, 21, 252, DateTimeKind.Local).AddTicks(595), "Caroline.Little4@yahoo.com", "Caroline", "Little" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BirthDate", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("a4db41de-b0c2-4d13-98bb-cee92ed26745"), new DateTime(1982, 3, 16, 6, 23, 6, 291, DateTimeKind.Local).AddTicks(8780), "Judy92@yahoo.com", "Judy", "Walter" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Email");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Caroline.Little4@yahoo.com",
                column: "BirthDate",
                value: new DateTime(2000, 12, 5, 10, 52, 21, 252, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "Judy92@yahoo.com",
                column: "BirthDate",
                value: new DateTime(1982, 3, 16, 7, 23, 6, 291, DateTimeKind.Local).AddTicks(8780));
        }
    }
}
