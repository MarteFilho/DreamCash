using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamCash.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlertInvestments",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlertTransfers",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertInvestments",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AlertTransfers",
                table: "User");
        }
    }
}
