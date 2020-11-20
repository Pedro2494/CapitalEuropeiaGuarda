using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitalEuropeiaGuarda.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aluguercarros",
                columns: table => new
                {
                    aluguercarrosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Lugares = table.Column<int>(nullable: false),
                    LinkReserva = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluguercarros", x => x.aluguercarrosId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aluguercarros");
        }
    }
}
