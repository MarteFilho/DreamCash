using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DreamCash.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_DestinationAccountId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_DestinationUserId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_DestinationAccountId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_DestinationUserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "DestinationAccountId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "DestinationUserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Transaction");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InvestimentDate",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvestimentId",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transaction",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investiment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investiment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_InvestimentId",
                table: "Transaction",
                column: "InvestimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Investiment_InvestimentId",
                table: "Transaction",
                column: "InvestimentId",
                principalTable: "Investiment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Investiment_InvestimentId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Investiment");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_InvestimentId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "InvestimentDate",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "InvestimentId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transaction");

            migrationBuilder.AddColumn<int>(
                name: "DestinationAccountId",
                table: "Transaction",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationUserId",
                table: "Transaction",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "Transaction",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_DestinationAccountId",
                table: "Transaction",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_DestinationUserId",
                table: "Transaction",
                column: "DestinationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_DestinationAccountId",
                table: "Transaction",
                column: "DestinationAccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_DestinationUserId",
                table: "Transaction",
                column: "DestinationUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
