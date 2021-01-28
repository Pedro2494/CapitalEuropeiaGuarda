using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitalEuropeiaGuarda.Migrations
{
    public partial class mig28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "PontoInteresse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "PontoInteresse");

            
        }
    }
}
