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
                    ActeurId = table.Column<int>(maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acteurs", x => x.ActeurId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Regisseurs",
                columns: table => new
                {
                    RegisseurId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regisseurs", x => x.RegisseurId);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(maxLength: 50, nullable: false),
                    Score = table.Column<double>(nullable: false),
                    RegisseurId = table.Column<int>(nullable: true),
                    TitleImage = table.Column<string>(nullable: true),
                    Runtime = table.Column<double>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_Films_Regisseurs_RegisseurId",
                        column: x => x.RegisseurId,
                        principalTable: "Regisseurs",
                        principalColumn: "RegisseurId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActeurFilm",
                columns: table => new
                {
                    ActeurId = table.Column<int>(nullable: false),
                    FilmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActeurFilm", x => new { x.ActeurId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_ActeurFilm_Acteurs_ActeurId",
                        column: x => x.ActeurId,
                        principalTable: "Acteurs",
                        principalColumn: "ActeurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActeurFilm_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreFilm",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    FilmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreFilm", x => new { x.GenreId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_GenreFilm_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreFilm_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActeurFilm_FilmId",
                table: "ActeurFilm",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_RegisseurId",
                table: "Films",
                column: "RegisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreFilm_FilmId",
                table: "GenreFilm",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActeurFilm");

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
