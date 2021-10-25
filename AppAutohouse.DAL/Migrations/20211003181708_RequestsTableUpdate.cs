using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAutohouse.DAL.Migrations
{
    public partial class RequestsTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CarId", "Name", "PhoneNumber", "RequestState", "Surname" },
                values: new object[] { 1, 1, "Yuliya", "111", 0, "Babuk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
