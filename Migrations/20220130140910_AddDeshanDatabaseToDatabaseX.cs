using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeshanWebApp.Migrations
{
    public partial class AddDeshanDatabaseToDatabaseX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Transfers");
        }
    }
}
