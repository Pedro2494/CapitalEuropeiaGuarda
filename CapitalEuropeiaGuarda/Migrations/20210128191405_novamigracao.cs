using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitalEuropeiaGuarda.Migrations
{
    public partial class novamigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresaaluguer",
                columns: table => new
                {
                    empresaaluguerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Max_lugares = table.Column<int>(nullable: false),
                    Min_lugares = table.Column<int>(nullable: false),
                    empresaaluguerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.VeiculoId);
                    table.ForeignKey(
                        name: "FK_Veiculo_Empresaaluguer_empresaaluguerId",
                        column: x => x.empresaaluguerId,
                        principalTable: "Empresaaluguer",
                        principalColumn: "empresaaluguerId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_empresaaluguerId",
                table: "Veiculo",
                column: "empresaaluguerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontoInteressePorHotel");

            migrationBuilder.DropTable(
                name: "ReservaExcursao");

            migrationBuilder.DropTable(
                name: "Turista");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Hoteis");

            migrationBuilder.DropTable(
                name: "PontoInteresse");

            migrationBuilder.DropTable(
                name: "Empresaaluguer");
        }
    }
}
