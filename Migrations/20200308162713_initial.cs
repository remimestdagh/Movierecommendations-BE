using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndRemiMestdagh.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acteurs",
                columns: table => new
                {
                    Naam = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acteurs", x => x.Naam);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Naam);
                });

            migrationBuilder.CreateTable(
                name: "Regisseurs",
                columns: table => new
                {
                    Naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regisseurs", x => x.Naam);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    ImdbId = table.Column<string>(nullable: false),
                    Titel = table.Column<string>(maxLength: 50, nullable: false),
                    Score = table.Column<double>(nullable: false),
                    RegisseurNaam = table.Column<string>(nullable: true),
                    TitleImage = table.Column<string>(nullable: true),
                    Runtime = table.Column<double>(nullable: false),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.ImdbId);
                    table.ForeignKey(
                        name: "FK_Films_Regisseurs_RegisseurNaam",
                        column: x => x.RegisseurNaam,
                        principalTable: "Regisseurs",
                        principalColumn: "Naam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActeurFilms",
                columns: table => new
                {
                    ActeurId = table.Column<string>(nullable: false),
                    FilmId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActeurFilms", x => new { x.ActeurId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_ActeurFilms_Acteurs_ActeurId",
                        column: x => x.ActeurId,
                        principalTable: "Acteurs",
                        principalColumn: "Naam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActeurFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "ImdbId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreFilm",
                columns: table => new
                {
                    GenreId = table.Column<string>(nullable: false),
                    FilmId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreFilm", x => new { x.GenreId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_GenreFilm_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "ImdbId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreFilm_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Naam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActeurFilms_FilmId",
                table: "ActeurFilms",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_RegisseurNaam",
                table: "Films",
                column: "RegisseurNaam");

            migrationBuilder.CreateIndex(
                name: "IX_GenreFilm_FilmId",
                table: "GenreFilm",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActeurFilms");

            migrationBuilder.DropTable(
                name: "GenreFilm");

            migrationBuilder.DropTable(
                name: "Acteurs");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Regisseurs");
        }
    }
}
