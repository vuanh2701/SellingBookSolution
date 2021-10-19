using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SellingBookSolution.Data.Migrations
{
    public partial class HomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeature",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e8eed33-489e-4f4a-80fb-9b04532690a5"),
                column: "ConcurrencyStamp",
                value: "8bd55002-59f3-400d-88bd-a6d13c6ac981");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8ce4b19b-15fc-4f01-a831-97319f99622c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "95852c30-4fd7-4aa4-86b7-c32caa56f5c2", "AQAAAAEAACcQAAAAECrMZsEa4yEQg4uL6FCVd1486u2SUVGEdj33RTYSouYCQUww9dIU+N49mSTFKF0q4g==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 27, 15, 48, 49, 228, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Description", "Image", "Name", "SortOrder", "Status", "Url" },
                values: new object[,]
                {
                    { 1, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/1.png", "Second Thumbnail label", 1, 1, "#" },
                    { 2, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/2.png", "Second Thumbnail label", 2, 1, "#" },
                    { 3, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/3.png", "Second Thumbnail label", 3, 1, "#" },
                    { 4, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/4.png", "Second Thumbnail label", 4, 1, "#" },
                    { 5, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/5.png", "Second Thumbnail label", 5, 1, "#" },
                    { 6, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/6.png", "Second Thumbnail label", 6, 1, "#" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropColumn(
                name: "IsFeature",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e8eed33-489e-4f4a-80fb-9b04532690a5"),
                column: "ConcurrencyStamp",
                value: "d55e6efb-08a5-4986-83b8-efbd537a3990");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8ce4b19b-15fc-4f01-a831-97319f99622c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "95ee8772-d74d-490a-b46d-d03ecc4a2d77", "AQAAAAEAACcQAAAAEANfGqVeTKfhXoQnX4XDObnM8Bh/HMoIUL9NcZW+XX0hkME3hSImy9ZDpZJwOsvNEQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 10, 16, 7, 14, 279, DateTimeKind.Local).AddTicks(9560));
        }
    }
}
