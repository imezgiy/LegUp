using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class tableUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ChatModel",
                table: "Messages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "ProductOwnerId",
                table: "Chats",
                newName: "ProductId");

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Messages",
                newName: "ChatModel");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Chats",
                newName: "ProductOwnerId");

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
