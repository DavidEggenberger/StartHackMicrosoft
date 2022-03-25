using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServer.Migrations
{
    public partial class trheed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Situtation",
                table: "Scenarios",
                newName: "Situation");

            migrationBuilder.AddColumn<int>(
                name: "MillisecondBreak",
                table: "ScenarioStep",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MillisecondBreak",
                table: "ScenarioStep");

            migrationBuilder.RenameColumn(
                name: "Situation",
                table: "Scenarios",
                newName: "Situtation");
        }
    }
}
