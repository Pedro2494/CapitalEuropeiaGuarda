using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitalEuropeiaGuarda.Migrations
{
    public partial class Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aluguercarros",
                columns: table => new
                {
                    aluguercarrosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    Lugares = table.Column<int>(nullable: false),
                    LinkReserva = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluguercarros", x => x.aluguercarrosId);
                });

            migrationBuilder.CreateTable(
                name: "Hoteis",
                columns: table => new
                {
                    HoteisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    DescricaoCurta = table.Column<string>(nullable: false),
                    HotelUrl = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteis", x => x.HoteisId);
                });

            migrationBuilder.CreateTable(
                name: "PontoInteresse",
                columns: table => new
                {
                    PontoInteresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Local = table.Column<string>(nullable: false),
                    DescricaoCurta = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoInteresse", x => x.PontoInteresseId);
                });

            migrationBuilder.CreateTable(
                name: "PontoInteressePorHotel",
                columns: table => new
                {
                    PontoInteressePorHotelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(nullable: false),
                    HoteisId = table.Column<int>(nullable: true),
                    PontoInteresseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoInteressePorHotel", x => x.PontoInteressePorHotelId);
                    table.ForeignKey(
                        name: "FK_PontoInteressePorHotel_Hoteis_HoteisId",
                        column: x => x.HoteisId,
                        principalTable: "Hoteis",
                        principalColumn: "HoteisId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontoInteressePorHotel_PontoInteresse_PontoInteresseId",
                        column: x => x.PontoInteresseId,
                        principalTable: "PontoInteresse",
                        principalColumn: "PontoInteresseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PontoInteressePorHotel_HoteisId",
                table: "PontoInteressePorHotel",
                column: "HoteisId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoInteressePorHotel_PontoInteresseId",
                table: "PontoInteressePorHotel",
                column: "PontoInteresseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aluguercarros");

            migrationBuilder.DropTable(
                name: "PontoInteressePorHotel");

            migrationBuilder.DropTable(
                name: "Hoteis");

            migrationBuilder.DropTable(
                name: "PontoInteresse");
        }
    }
}
