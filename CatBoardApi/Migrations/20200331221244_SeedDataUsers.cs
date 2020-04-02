using Microsoft.EntityFrameworkCore.Migrations;

namespace CatBoardApi.Migrations
{
    public partial class SeedDataUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "123@gmail", "John", "1" },
                    { 2, "Cats@cats.com", "Markus", "1" },
                    { 3, "ilovecats@gmail.com", "Lilly", "1" },
                    { 4, "dogseatcatpoo@yahoo.com", "Jordan", "1" }
                });
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

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);
        }
    }
}
