using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitalEuropeiaGuarda.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservaExcursao",
                columns: table => new
                {
                    ReservaExcursaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataReserva = table.Column<string>(nullable: true),
                    NumPessoas = table.Column<int>(nullable: false),
                    Cancelado = table.Column<bool>(nullable: false),
                    DataCancelar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaExcursao", x => x.ReservaExcursaoId);
                });

            migrationBuilder.CreateTable(
                name: "Turista",
                columns: table => new
                {
                    TuristaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Nif = table.Column<int>(nullable: false),
                    Telemovel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turista", x => x.TuristaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaExcursao");

            migrationBuilder.DropTable(
                name: "Turista");
        }
    }
}
