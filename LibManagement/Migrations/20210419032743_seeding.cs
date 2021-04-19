using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibManagement.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DoB", "Name", "Password", "Role", "Username" },
                values: new object[] { 1, new DateTime(2001, 4, 19, 10, 27, 43, 457, DateTimeKind.Local).AddTicks(5293), "Nguyen Van A", "123", 0, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DoB", "Name", "Password", "Role", "Username" },
                values: new object[] { 2, new DateTime(1991, 4, 19, 10, 27, 43, 458, DateTimeKind.Local).AddTicks(4803), "Nguyen Van B", "123", 1, "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
