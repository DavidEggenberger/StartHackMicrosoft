using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServer.Migrations
{
    public partial class twwea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LearningId",
                table: "ScenarioStep",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Learnings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ratings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learnings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioStep_LearningId",
                table: "ScenarioStep",
                column: "LearningId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScenarioStep_Learnings_LearningId",
                table: "ScenarioStep",
                column: "LearningId",
                principalTable: "Learnings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScenarioStep_Learnings_LearningId",
                table: "ScenarioStep");

            migrationBuilder.DropTable(
                name: "Learnings");

            migrationBuilder.DropIndex(
                name: "IX_ScenarioStep_LearningId",
                table: "ScenarioStep");

            migrationBuilder.DropColumn(
                name: "LearningId",
                table: "ScenarioStep");
        }
    }
}
