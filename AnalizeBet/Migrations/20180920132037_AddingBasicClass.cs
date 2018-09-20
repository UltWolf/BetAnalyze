using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalizeBet.Migrations
{
    public partial class AddingBasicClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ProcentToWin",
                table: "Scores",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcentToWin",
                table: "Scores");
        }
    }
}
