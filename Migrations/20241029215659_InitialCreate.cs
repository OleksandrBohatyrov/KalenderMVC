using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalenderMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kasutajad",
                columns: table => new
                {
                    KasutajaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kasutajanimi = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Salasona = table.Column<string>(type: "TEXT", nullable: false),
                    Loodud = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kasutajad", x => x.KasutajaId);
                });

            migrationBuilder.CreateTable(
                name: "Sondmused",
                columns: table => new
                {
                    SondmusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pealkiri = table.Column<string>(type: "TEXT", nullable: false),
                    Kirjeldus = table.Column<string>(type: "TEXT", nullable: false),
                    AlgusAeg = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LoppAeg = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KasutajaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sondmused", x => x.SondmusId);
                    table.ForeignKey(
                        name: "FK_Sondmused_Kasutajad_KasutajaId",
                        column: x => x.KasutajaId,
                        principalTable: "Kasutajad",
                        principalColumn: "KasutajaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meeldetuletused",
                columns: table => new
                {
                    MeeldetuletusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeeldetuletuseAeg = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SondmusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeldetuletused", x => x.MeeldetuletusId);
                    table.ForeignKey(
                        name: "FK_Meeldetuletused_Sondmused_SondmusId",
                        column: x => x.SondmusId,
                        principalTable: "Sondmused",
                        principalColumn: "SondmusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeldetuletused_SondmusId",
                table: "Meeldetuletused",
                column: "SondmusId");

            migrationBuilder.CreateIndex(
                name: "IX_Sondmused_KasutajaId",
                table: "Sondmused",
                column: "KasutajaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeldetuletused");

            migrationBuilder.DropTable(
                name: "Sondmused");

            migrationBuilder.DropTable(
                name: "Kasutajad");
        }
    }
}
