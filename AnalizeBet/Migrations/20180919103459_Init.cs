using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalizeBet.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    League = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    FirstScore = table.Column<int>(nullable: false),
                    SecondScore = table.Column<int>(nullable: false),
                    FirstTeam = table.Column<string>(nullable: true),
                    SecondTeam = table.Column<string>(nullable: true),
                    Result = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");
        }
    }
}
