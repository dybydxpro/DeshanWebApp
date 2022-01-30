using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeshanWebApp.Migrations
{
    public partial class AddDeshanDatabaseToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TID",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TID",
                table: "Transfers");
        }
    }
}
