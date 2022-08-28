using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetCore6Test.Migrations
{
    public partial class PostsAndComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2a8ce4c1-20d7-4ec5-874a-7793d03fee90"));

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PostId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Body = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Body = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Link = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("850ad099-f3f5-4315-a03f-ea45025cc65c"), "test@test.com", "First", true, "Last", new byte[] { 229, 73, 110, 178, 184, 91, 9, 87, 183, 200, 48, 14, 119, 32, 198, 154, 13, 170, 51, 81, 134, 138, 87, 243, 86, 175, 80, 201, 212, 158, 140, 104, 174, 179, 208, 110, 148, 251, 219, 14, 241, 190, 170, 131, 139, 31, 68, 11, 97, 251, 57, 15, 160, 199, 133, 243, 169, 49, 4, 4, 87, 220, 207, 98 }, new byte[] { 224, 201, 228, 137, 158, 5, 30, 39, 183, 8, 99, 89, 244, 189, 106, 109, 212, 42, 26, 201, 139, 54, 250, 212, 35, 124, 79, 18, 24, 221, 206, 83, 9, 172, 227, 43, 59, 32, 139, 142, 39, 252, 59, 133, 65, 42, 228, 133, 181, 1, 94, 124, 69, 157, 218, 81, 222, 153, 131, 181, 222, 107, 19, 176, 57, 229, 63, 244, 93, 105, 139, 106, 88, 204, 204, 3, 124, 204, 158, 234, 115, 34, 213, 141, 127, 134, 235, 177, 2, 124, 124, 229, 6, 128, 23, 47, 115, 29, 188, 46, 199, 168, 155, 194, 239, 143, 75, 122, 57, 78, 58, 57, 17, 80, 255, 27, 49, 166, 127, 245, 138, 29, 20, 225, 93, 143, 141, 153 }, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("850ad099-f3f5-4315-a03f-ea45025cc65c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("2a8ce4c1-20d7-4ec5-874a-7793d03fee90"), "test@test.com", "First", true, "Last", new byte[] { 79, 111, 252, 32, 50, 99, 51, 55, 31, 211, 253, 75, 54, 10, 130, 186, 178, 240, 200, 104, 11, 169, 93, 211, 55, 60, 189, 72, 43, 27, 247, 138, 159, 137, 88, 63, 167, 208, 61, 69, 109, 122, 93, 61, 134, 203, 106, 223, 112, 165, 121, 97, 137, 125, 2, 19, 218, 194, 231, 203, 140, 250, 93, 175 }, new byte[] { 171, 232, 11, 186, 255, 210, 38, 77, 159, 150, 30, 138, 254, 150, 45, 82, 185, 144, 139, 4, 29, 203, 58, 34, 24, 203, 66, 23, 8, 187, 229, 163, 130, 156, 124, 128, 232, 84, 150, 188, 31, 24, 94, 70, 188, 247, 145, 78, 159, 160, 212, 59, 39, 244, 105, 79, 164, 219, 85, 126, 200, 250, 21, 56, 28, 188, 94, 20, 181, 46, 189, 69, 162, 182, 156, 171, 129, 176, 164, 139, 164, 7, 225, 30, 195, 212, 211, 221, 151, 161, 53, 2, 25, 112, 241, 186, 65, 247, 142, 156, 100, 52, 20, 236, 2, 134, 182, 58, 8, 22, 150, 240, 187, 134, 207, 91, 154, 194, 242, 6, 105, 5, 234, 180, 7, 203, 46, 210 }, "" });
        }
    }
}
