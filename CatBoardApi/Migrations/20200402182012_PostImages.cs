using Microsoft.EntityFrameworkCore.Migrations;

namespace CatBoardApi.Migrations
{
    public partial class PostImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Posts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "ImageSource",
                value: "https://www.writeups.org/wp-content/uploads/Rick-Sanchez-Rick-and-Morty.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "ImageSource",
                value: "https://www.writeups.org/wp-content/uploads/Rick-Sanchez-Rick-and-Morty.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "ImageSource",
                value: "https://www.writeups.org/wp-content/uploads/Rick-Sanchez-Rick-and-Morty.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "ImageSource",
                value: "https://www.writeups.org/wp-content/uploads/Rick-Sanchez-Rick-and-Morty.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Posts");
        }
    }
}
