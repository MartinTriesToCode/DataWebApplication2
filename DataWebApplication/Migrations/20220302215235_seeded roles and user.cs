using Microsoft.EntityFrameworkCore.Migrations;

namespace DataWebApplication.Migrations
{
    public partial class seededrolesanduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c22a20ea-f8ca-4d28-9a99-aa74be7f7826", "9b36b9ad-a56c-455c-ab2c-8200a0d90989", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b4b6681-6ba7-41cc-97d9-e14f8a826c6b", "a4842a09-d0d7-4cfa-9c41-04ad3233e59e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f61489d6-9b99-4124-a1c2-c451120ce083", 0, "1990-01-01-8989", "d826e575-5acb-4ef9-ab0b-0fff7c982b09", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMez2c2u0IuGkMMY0P6aR20YDBn/teH/FjF4tc70mhJVWwCARaMh+zRzS/HZcYlqbQ==", null, false, "7714a27b-b88d-47bd-bf78-a63a734efaac", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c22a20ea-f8ca-4d28-9a99-aa74be7f7826", "f61489d6-9b99-4124-a1c2-c451120ce083" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b4b6681-6ba7-41cc-97d9-e14f8a826c6b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c22a20ea-f8ca-4d28-9a99-aa74be7f7826", "f61489d6-9b99-4124-a1c2-c451120ce083" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c22a20ea-f8ca-4d28-9a99-aa74be7f7826");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f61489d6-9b99-4124-a1c2-c451120ce083");
        }
    }
}
