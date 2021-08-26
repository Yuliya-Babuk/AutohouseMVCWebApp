using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAutohouse.DAL.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "Logo",
                value: "https://logos-world.net/wp-content/uploads/2021/04/Volkswagen-Logo.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "Logo",
                value: "http://cdn29.us1.fansshare.com/pictures/volkswagengroup/banner-volkswagen-logo-vector-logo-1478455335.jpg");
        }
    }
}
