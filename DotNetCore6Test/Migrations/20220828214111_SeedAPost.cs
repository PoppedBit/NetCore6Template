using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetCore6Test.Migrations
{
    public partial class SeedAPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("850ad099-f3f5-4315-a03f-ea45025cc65c"));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "CreatedTimestamp", "Link", "Title" },
                values: new object[] { new Guid("8e6fff8a-d16a-43df-aeaa-74726b1d58b6"), new Guid("5d35e99c-65cd-4c3c-ac27-833ca65db51d"), "This is a test body", new DateTime(2022, 8, 28, 21, 41, 11, 740, DateTimeKind.Utc).AddTicks(387), "https://www.twitch.tv/", "This is a test title" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("5d35e99c-65cd-4c3c-ac27-833ca65db51d"), "test@test.com", "First", true, "Last", new byte[] { 48, 171, 2, 61, 210, 50, 250, 44, 20, 103, 140, 148, 182, 127, 171, 99, 119, 151, 144, 200, 5, 140, 166, 43, 194, 96, 224, 173, 86, 12, 173, 127, 212, 176, 159, 16, 154, 40, 222, 178, 95, 5, 236, 112, 119, 52, 185, 38, 230, 193, 173, 88, 226, 157, 28, 154, 201, 191, 197, 238, 248, 0, 75, 231 }, new byte[] { 15, 109, 48, 158, 232, 160, 143, 7, 87, 234, 197, 99, 139, 255, 33, 235, 86, 209, 107, 81, 174, 85, 153, 36, 67, 78, 14, 109, 107, 149, 123, 111, 163, 41, 161, 103, 58, 63, 114, 179, 240, 215, 32, 183, 106, 155, 164, 111, 136, 92, 136, 13, 165, 187, 106, 222, 69, 16, 238, 166, 181, 128, 85, 231, 60, 62, 78, 219, 166, 67, 234, 114, 12, 218, 49, 138, 146, 126, 254, 253, 123, 205, 63, 183, 230, 81, 133, 18, 200, 31, 107, 237, 90, 255, 116, 3, 232, 142, 25, 16, 184, 4, 22, 20, 220, 200, 191, 139, 81, 209, 90, 147, 244, 95, 113, 93, 197, 9, 56, 172, 127, 172, 5, 169, 16, 31, 28, 135 }, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8e6fff8a-d16a-43df-aeaa-74726b1d58b6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5d35e99c-65cd-4c3c-ac27-833ca65db51d"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("850ad099-f3f5-4315-a03f-ea45025cc65c"), "test@test.com", "First", true, "Last", new byte[] { 229, 73, 110, 178, 184, 91, 9, 87, 183, 200, 48, 14, 119, 32, 198, 154, 13, 170, 51, 81, 134, 138, 87, 243, 86, 175, 80, 201, 212, 158, 140, 104, 174, 179, 208, 110, 148, 251, 219, 14, 241, 190, 170, 131, 139, 31, 68, 11, 97, 251, 57, 15, 160, 199, 133, 243, 169, 49, 4, 4, 87, 220, 207, 98 }, new byte[] { 224, 201, 228, 137, 158, 5, 30, 39, 183, 8, 99, 89, 244, 189, 106, 109, 212, 42, 26, 201, 139, 54, 250, 212, 35, 124, 79, 18, 24, 221, 206, 83, 9, 172, 227, 43, 59, 32, 139, 142, 39, 252, 59, 133, 65, 42, 228, 133, 181, 1, 94, 124, 69, 157, 218, 81, 222, 153, 131, 181, 222, 107, 19, 176, 57, 229, 63, 244, 93, 105, 139, 106, 88, 204, 204, 3, 124, 204, 158, 234, 115, 34, 213, 141, 127, 134, 235, 177, 2, 124, 124, 229, 6, 128, 23, 47, 115, 29, 188, 46, 199, 168, 155, 194, 239, 143, 75, 122, 57, 78, 58, 57, 17, 80, 255, 27, 49, 166, 127, 245, 138, 29, 20, 225, 93, 143, 141, 153 }, "" });
        }
    }
}
