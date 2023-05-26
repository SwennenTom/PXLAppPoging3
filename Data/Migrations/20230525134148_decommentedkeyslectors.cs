using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXLApp3.Data.Migrations
{
    public partial class decommentedkeyslectors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lectors_gebruikers_GebruikerId",
                table: "lectors");

            migrationBuilder.AlterColumn<int>(
                name: "GebruikerId",
                table: "lectors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lectors_gebruikers_GebruikerId",
                table: "lectors",
                column: "GebruikerId",
                principalTable: "gebruikers",
                principalColumn: "GebruikerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lectors_gebruikers_GebruikerId",
                table: "lectors");

            migrationBuilder.AlterColumn<int>(
                name: "GebruikerId",
                table: "lectors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_lectors_gebruikers_GebruikerId",
                table: "lectors",
                column: "GebruikerId",
                principalTable: "gebruikers",
                principalColumn: "GebruikerId");
        }
    }
}
