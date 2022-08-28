using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetCore6Test.Migrations
{
    public partial class FixCommentsTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8e6fff8a-d16a-43df-aeaa-74726b1d58b6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5d35e99c-65cd-4c3c-ac27-833ca65db51d"));

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "CreatedTimestamp", "Link", "Title" },
                values: new object[] { new Guid("c412a9f1-d5ff-4ceb-a1a0-2e5d59c51a3b"), new Guid("f622f48a-a244-40cc-9efe-4efcaa067a96"), "This is a test body", new DateTime(2022, 8, 28, 22, 18, 21, 157, DateTimeKind.Utc).AddTicks(5575), "https://www.twitch.tv/", "This is a test title" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("f622f48a-a244-40cc-9efe-4efcaa067a96"), "test@test.com", "First", true, "Last", new byte[] { 229, 46, 76, 123, 154, 84, 200, 24, 247, 183, 53, 199, 117, 109, 78, 190, 6, 62, 89, 120, 200, 137, 43, 213, 27, 4, 32, 207, 100, 211, 194, 94, 112, 132, 179, 172, 242, 190, 81, 170, 189, 12, 139, 31, 138, 128, 74, 60, 4, 142, 118, 119, 124, 30, 80, 246, 129, 137, 43, 251, 42, 230, 3, 51 }, new byte[] { 90, 69, 10, 126, 6, 62, 204, 191, 70, 46, 40, 169, 178, 108, 232, 170, 73, 0, 226, 127, 41, 166, 235, 102, 142, 28, 36, 110, 205, 183, 254, 255, 129, 116, 31, 205, 141, 98, 164, 163, 165, 208, 84, 50, 197, 154, 141, 226, 19, 96, 51, 79, 238, 196, 10, 148, 2, 42, 121, 111, 32, 116, 234, 200, 91, 4, 233, 142, 73, 89, 26, 27, 156, 88, 227, 0, 164, 98, 10, 150, 46, 202, 247, 178, 96, 246, 167, 240, 184, 94, 82, 183, 7, 6, 73, 102, 149, 231, 46, 113, 185, 156, 115, 244, 117, 179, 147, 196, 52, 56, 195, 36, 196, 33, 234, 167, 9, 159, 184, 185, 129, 94, 207, 21, 204, 155, 229, 252 }, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("c412a9f1-d5ff-4ceb-a1a0-2e5d59c51a3b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f622f48a-a244-40cc-9efe-4efcaa067a96"));

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "CreatedTimestamp", "Link", "Title" },
                values: new object[] { new Guid("8e6fff8a-d16a-43df-aeaa-74726b1d58b6"), new Guid("5d35e99c-65cd-4c3c-ac27-833ca65db51d"), "This is a test body", new DateTime(2022, 8, 28, 21, 41, 11, 740, DateTimeKind.Utc).AddTicks(387), "https://www.twitch.tv/", "This is a test title" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("5d35e99c-65cd-4c3c-ac27-833ca65db51d"), "test@test.com", "First", true, "Last", new byte[] { 48, 171, 2, 61, 210, 50, 250, 44, 20, 103, 140, 148, 182, 127, 171, 99, 119, 151, 144, 200, 5, 140, 166, 43, 194, 96, 224, 173, 86, 12, 173, 127, 212, 176, 159, 16, 154, 40, 222, 178, 95, 5, 236, 112, 119, 52, 185, 38, 230, 193, 173, 88, 226, 157, 28, 154, 201, 191, 197, 238, 248, 0, 75, 231 }, new byte[] { 15, 109, 48, 158, 232, 160, 143, 7, 87, 234, 197, 99, 139, 255, 33, 235, 86, 209, 107, 81, 174, 85, 153, 36, 67, 78, 14, 109, 107, 149, 123, 111, 163, 41, 161, 103, 58, 63, 114, 179, 240, 215, 32, 183, 106, 155, 164, 111, 136, 92, 136, 13, 165, 187, 106, 222, 69, 16, 238, 166, 181, 128, 85, 231, 60, 62, 78, 219, 166, 67, 234, 114, 12, 218, 49, 138, 146, 126, 254, 253, 123, 205, 63, 183, 230, 81, 133, 18, 200, 31, 107, 237, 90, 255, 116, 3, 232, 142, 25, 16, 184, 4, 22, 20, 220, 200, 191, 139, 81, 209, 90, 147, 244, 95, 113, 93, 197, 9, 56, 172, 127, 172, 5, 169, 16, 31, 28, 135 }, "" });
        }
    }
}
