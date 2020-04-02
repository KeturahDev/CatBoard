using Microsoft.EntityFrameworkCore.Migrations;

namespace CatBoardApi.Migrations
{
    public partial class BannerImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BannerImage",
                table: "Boards",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 1,
                column: "BannerImage",
                value: "https://images.unsplash.com/photo-1478098711619-5ab0b478d6e6?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1500&q=80");

            migrationBuilder.UpdateData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 2,
                column: "BannerImage",
                value: "https://image.shutterstock.com/image-photo/banner-cat-web-header-template-260nw-1030847524.jpg");

            migrationBuilder.UpdateData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 3,
                column: "BannerImage",
                value: "https://images.unsplash.com/photo-1577359472653-792a974e6be2?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1494&q=80");

            migrationBuilder.UpdateData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 4,
                column: "BannerImage",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQIUWQ0gHjMSzA0budASFKXc12BXQUGnm8xBl3d9U-_ObGfNCXS&usqp=CAU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerImage",
                table: "Boards");
        }
    }
}
