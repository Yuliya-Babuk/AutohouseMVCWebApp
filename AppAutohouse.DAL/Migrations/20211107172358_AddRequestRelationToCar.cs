using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAutohouse.DAL.Migrations
{
    public partial class AddRequestRelationToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requests_CarId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CarId",
                table: "Requests",
                column: "CarId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requests_CarId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CarId",
                table: "Requests",
                column: "CarId");
        }
    }
}
