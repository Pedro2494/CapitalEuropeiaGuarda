﻿// <auto-generated />
using CapitalEuropeiaGuarda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CapitalEuropeiaGuarda.Migrations
{
    [DbContext(typeof(CapitalEuropeiaGuardaContext))]
    [Migration("20201120120506_PontosMigration")]
    partial class PontosMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.PontoInteresse", b =>
                {
                    b.Property<int>("PontoInteresseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoCurta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PontoInteresseId");

                    b.ToTable("PontoInteresse");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.aluguercarros", b =>
                {
                    b.Property<int>("aluguercarrosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LinkReserva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lugares")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("aluguercarrosId");

                    b.ToTable("aluguercarros");
                });
#pragma warning restore 612, 618
        }
    }
}
