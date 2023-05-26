using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXLApp3.Data.Migrations
{
    public partial class AllThingsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vakLectoren_lectors_LectorId",
                table: "vakLectoren");

            migrationBuilder.DropForeignKey(
                name: "FK_vakLectoren_vakken_VakId",
                table: "vakLectoren");

            migrationBuilder.AlterColumn<int>(
                name: "VakId",
                table: "vakLectoren",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LectorId",
                table: "vakLectoren",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_vakLectoren_lectors_LectorId",
                table: "vakLectoren",
                column: "LectorId",
                principalTable: "lectors",
                principalColumn: "LectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_vakLectoren_vakken_VakId",
                table: "vakLectoren",
                column: "VakId",
                principalTable: "vakken",
                principalColumn: "VakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vakLectoren_lectors_LectorId",
                table: "vakLectoren");

            migrationBuilder.DropForeignKey(
                name: "FK_vakLectoren_vakken_VakId",
                table: "vakLectoren");

            migrationBuilder.AlterColumn<int>(
                name: "VakId",
                table: "vakLectoren",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LectorId",
                table: "vakLectoren",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_vakLectoren_lectors_LectorId",
                table: "vakLectoren",
                column: "LectorId",
                principalTable: "lectors",
                principalColumn: "LectorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vakLectoren_vakken_VakId",
                table: "vakLectoren",
                column: "VakId",
                principalTable: "vakken",
                principalColumn: "VakId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
