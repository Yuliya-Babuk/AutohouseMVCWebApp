using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAutohouse.DAL.Migrations
{
    public partial class AddPhotoField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "https://www.allcarz.ru/wp-content/uploads/2014/12/foto-a6-c8_01.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3MMxr7bxxafFWCxseDynxtkzJS3-oiCuLVw&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Photo",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7viimLHsFRXmGUmN8Vjxi7zRkzX7LQGpICg&usqp=CAU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Cars");
        }
    }
}
