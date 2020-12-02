using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamCash.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Investiment_InvestimentId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Investiment");

            migrationBuilder.AlterColumn<long>(
                name: "Amount",
                table: "Account",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.CreateTable(
                name: "Investment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MinimumValue = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investment_UserId",
                table: "Investment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Investment_InvestimentId",
                table: "Transaction",
                column: "InvestimentId",
                principalTable: "Investment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Investment_InvestimentId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Investment");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Account",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "Investiment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MinimumValue = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investiment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investiment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investiment_UserId",
                table: "Investiment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Investiment_InvestimentId",
                table: "Transaction",
                column: "InvestimentId",
                principalTable: "Investiment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
