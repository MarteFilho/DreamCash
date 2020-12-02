using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamCash.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MinimumValue",
                table: "Investiment",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumValue",
                table: "Investiment");
        }
    }
}
