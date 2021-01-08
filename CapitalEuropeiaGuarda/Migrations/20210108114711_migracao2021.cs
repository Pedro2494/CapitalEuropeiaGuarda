using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitalEuropeiaGuarda.Migrations
{
    public partial class migracao2021 : Migration
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
                name: "Empresaaluguer",
                columns: table => new
                {
                    empresaaluguerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresaaluguer", x => x.empresaaluguerId);
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
                name: "Veiculo",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Max_lugares = table.Column<int>(nullable: false),
                    Min_lugares = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.VeiculoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aluguercarros");

            migrationBuilder.DropTable(
                name: "Empresaaluguer");

            migrationBuilder.DropTable(
                name: "Hoteis");

            migrationBuilder.DropTable(
                name: "PontoInteresse");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
