using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondHand.Migrations
{
    public partial class Zadnja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obutevs");

            migrationBuilder.DropTable(
                name: "KategorijeCevljis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KategorijeCevljis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKategorije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spol = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijeCevljis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Obutevs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImeCevlja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorijaId = table.Column<int>(type: "int", nullable: false),
                    SlikaCevljaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StCevlja = table.Column<double>(type: "float", nullable: false),
                    cena = table.Column<double>(type: "float", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ownerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    znamka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obutevs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obutevs_AspNetUsers_ownerId",
                        column: x => x.ownerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obutevs_KategorijeCevljis_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "KategorijeCevljis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obutevs_KategorijaId",
                table: "Obutevs",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obutevs_ownerId",
                table: "Obutevs",
                column: "ownerId");
        }
    }
}
