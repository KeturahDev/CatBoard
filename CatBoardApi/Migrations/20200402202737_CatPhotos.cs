using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatBoardApi.Migrations
{
    public partial class CatPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "ImageSource",
                value: "https://pbs.twimg.com/profile_images/1080545769034108928/CEzHCTpI_400x400.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "ImageSource",
                value: "https://pbs.twimg.com/profile_images/1080545769034108928/CEzHCTpI_400x400.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "ImageSource",
                value: "https://pbs.twimg.com/profile_images/1080545769034108928/CEzHCTpI_400x400.jpg");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "ImageSource",
                value: "https://pbs.twimg.com/profile_images/1080545769034108928/CEzHCTpI_400x400.jpg");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "BoardId", "Body", "DateCreated", "EditDate", "ImageSource", "Score", "Title" },
                values: new object[] { 5, 1, 2, "this cat got into the mustard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.redd.it/edle727b0sx11.jpg", 0, "mustards" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5);

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
    }
}
