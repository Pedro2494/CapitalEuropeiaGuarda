using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitalEuropeiaGuarda.Migrations
{
    public partial class migfoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontoInteressePorHotel_PontoInteresse_PontoInteresseId",
                table: "PontoInteressePorHotel");

            migrationBuilder.AlterColumn<int>(
                name: "PontoInteresseId",
                table: "PontoInteressePorHotel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "PontoInteressePorHotel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Hoteis",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PontoInteressePorHotel_PontoInteresse_PontoInteresseId",
                table: "PontoInteressePorHotel",
                column: "PontoInteresseId",
                principalTable: "PontoInteresse",
                principalColumn: "PontoInteresseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontoInteressePorHotel_PontoInteresse_PontoInteresseId",
                table: "PontoInteressePorHotel");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Hoteis");

            migrationBuilder.AlterColumn<int>(
                name: "PontoInteresseId",
                table: "PontoInteressePorHotel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "PontoInteressePorHotel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PontoInteressePorHotel_PontoInteresse_PontoInteresseId",
                table: "PontoInteressePorHotel",
                column: "PontoInteresseId",
                principalTable: "PontoInteresse",
                principalColumn: "PontoInteresseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
