using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetCore6Test.Migrations
{
    public partial class SeedingUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("2a8ce4c1-20d7-4ec5-874a-7793d03fee90"), "test@test.com", "First", true, "Last", new byte[] { 79, 111, 252, 32, 50, 99, 51, 55, 31, 211, 253, 75, 54, 10, 130, 186, 178, 240, 200, 104, 11, 169, 93, 211, 55, 60, 189, 72, 43, 27, 247, 138, 159, 137, 88, 63, 167, 208, 61, 69, 109, 122, 93, 61, 134, 203, 106, 223, 112, 165, 121, 97, 137, 125, 2, 19, 218, 194, 231, 203, 140, 250, 93, 175 }, new byte[] { 171, 232, 11, 186, 255, 210, 38, 77, 159, 150, 30, 138, 254, 150, 45, 82, 185, 144, 139, 4, 29, 203, 58, 34, 24, 203, 66, 23, 8, 187, 229, 163, 130, 156, 124, 128, 232, 84, 150, 188, 31, 24, 94, 70, 188, 247, 145, 78, 159, 160, 212, 59, 39, 244, 105, 79, 164, 219, 85, 126, 200, 250, 21, 56, 28, 188, 94, 20, 181, 46, 189, 69, 162, 182, 156, 171, 129, 176, 164, 139, 164, 7, 225, 30, 195, 212, 211, 221, 151, 161, 53, 2, 25, 112, 241, 186, 65, 247, 142, 156, 100, 52, 20, 236, 2, 134, 182, 58, 8, 22, 150, 240, 187, 134, 207, 91, 154, 194, 242, 6, 105, 5, 234, 180, 7, 203, 46, 210 }, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2a8ce4c1-20d7-4ec5-874a-7793d03fee90"));
        }
    }
}
