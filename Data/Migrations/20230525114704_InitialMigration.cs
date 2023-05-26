using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PXLApp3.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "academieJaren",
                columns: table => new
                {
                    AcademieJaarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academieJaren", x => x.AcademieJaarId);
                });

            migrationBuilder.CreateTable(
                name: "gebruikers",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gebruikers", x => x.GebruikerId);
                });

            migrationBuilder.CreateTable(
                name: "handboeken",
                columns: table => new
                {
                    HandboekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KostPrijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uitgiftedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Afbeelding = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_handboeken", x => x.HandboekId);
                });

            migrationBuilder.CreateTable(
                name: "lectors",
                columns: table => new
                {
                    LectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lectors", x => x.LectorId);
                    table.ForeignKey(
                        name: "FK_lectors_gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "gebruikers",
                        principalColumn: "GebruikerId");
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_students_gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "gebruikers",
                        principalColumn: "GebruikerId");
                });

            migrationBuilder.CreateTable(
                name: "vakken",
                columns: table => new
                {
                    VakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VakNaam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Studiepunten = table.Column<int>(type: "int", nullable: false),
                    HandboekId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vakken", x => x.VakId);
                    table.ForeignKey(
                        name: "FK_vakken_handboeken_HandboekId",
                        column: x => x.HandboekId,
                        principalTable: "handboeken",
                        principalColumn: "HandboekId");
                });

            migrationBuilder.CreateTable(
                name: "vakLectoren",
                columns: table => new
                {
                    VakLectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VakId = table.Column<int>(type: "int", nullable: false),
                    LectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vakLectoren", x => x.VakLectorId);
                    table.ForeignKey(
                        name: "FK_vakLectoren_lectors_LectorId",
                        column: x => x.LectorId,
                        principalTable: "lectors",
                        principalColumn: "LectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vakLectoren_vakken_VakId",
                        column: x => x.VakId,
                        principalTable: "vakken",
                        principalColumn: "VakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inschrijvingen",
                columns: table => new
                {
                    InschrijvingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    VakLectorId = table.Column<int>(type: "int", nullable: true),
                    AcademieJaarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inschrijvingen", x => x.InschrijvingId);
                    table.ForeignKey(
                        name: "FK_inschrijvingen_academieJaren_AcademieJaarId",
                        column: x => x.AcademieJaarId,
                        principalTable: "academieJaren",
                        principalColumn: "AcademieJaarId");
                    table.ForeignKey(
                        name: "FK_inschrijvingen_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "StudentId");
                    table.ForeignKey(
                        name: "FK_inschrijvingen_vakLectoren_VakLectorId",
                        column: x => x.VakLectorId,
                        principalTable: "vakLectoren",
                        principalColumn: "VakLectorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_inschrijvingen_AcademieJaarId",
                table: "inschrijvingen",
                column: "AcademieJaarId");

            migrationBuilder.CreateIndex(
                name: "IX_inschrijvingen_StudentId",
                table: "inschrijvingen",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_inschrijvingen_VakLectorId",
                table: "inschrijvingen",
                column: "VakLectorId");

            migrationBuilder.CreateIndex(
                name: "IX_lectors_GebruikerId",
                table: "lectors",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_students_GebruikerId",
                table: "students",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_vakken_HandboekId",
                table: "vakken",
                column: "HandboekId");

            migrationBuilder.CreateIndex(
                name: "IX_vakLectoren_LectorId",
                table: "vakLectoren",
                column: "LectorId");

            migrationBuilder.CreateIndex(
                name: "IX_vakLectoren_VakId",
                table: "vakLectoren",
                column: "VakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inschrijvingen");

            migrationBuilder.DropTable(
                name: "academieJaren");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "vakLectoren");

            migrationBuilder.DropTable(
                name: "lectors");

            migrationBuilder.DropTable(
                name: "vakken");

            migrationBuilder.DropTable(
                name: "gebruikers");

            migrationBuilder.DropTable(
                name: "handboeken");
        }
    }
}
