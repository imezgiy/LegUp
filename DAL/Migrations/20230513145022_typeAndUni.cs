using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class typeAndUni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HelpTypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Products");
        }
    }
}
