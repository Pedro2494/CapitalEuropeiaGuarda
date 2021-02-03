﻿// <auto-generated />
using System;
using CapitalEuropeiaGuarda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CapitalEuropeiaGuarda.Migrations
{
    [DbContext(typeof(CapitalEuropeiaGuardaContext))]
    partial class CapitalEuropeiaGuardaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.Empresaaluguer", b =>
                {
                    b.Property<int>("empresaaluguerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("empresaaluguerId");

                    b.ToTable("Empresaaluguer");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.Hoteis", b =>
                {
                    b.Property<int>("HoteisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoCurta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("HoteisId");

                    b.ToTable("Hoteis");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.Local", b =>
                {
                    b.Property<int>("localID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Concelho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coordenadas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("localID");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.PontoInteresse", b =>
                {
                    b.Property<int>("PontoInteresseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoCurta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Photo2")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PontoInteresseId");

                    b.ToTable("PontoInteresse");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.PontoInteressePorHotel", b =>
                {
                    b.Property<int>("PontoInteressePorHotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HoteisId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("PontoInteresseId")
                        .HasColumnType("int");

                    b.HasKey("PontoInteressePorHotelId");

                    b.HasIndex("HoteisId");

                    b.HasIndex("PontoInteresseId");

                    b.ToTable("PontoInteressePorHotel");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.ReservaExcursao", b =>
                {
                    b.Property<int>("ReservaExcursaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Cancelado")
                        .HasColumnType("bit");

                    b.Property<string>("DataCancelar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataReserva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumPessoas")
                        .HasColumnType("int");

                    b.Property<int?>("TuristaId")
                        .HasColumnType("int");

                    b.HasKey("ReservaExcursaoId");

                    b.HasIndex("TuristaId");

                    b.ToTable("ReservaExcursao");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.Turista", b =>
                {
                    b.Property<int>("TuristaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nif")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TuristaId");

                    b.ToTable("Turista");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.Veiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Max_lugares")
                        .HasColumnType("int");

                    b.Property<int>("Min_lugares")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("empresaaluguerId")
                        .HasColumnType("int");

                    b.HasKey("VeiculoId");

                    b.HasIndex("empresaaluguerId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.PontoInteressePorHotel", b =>
                {
                    b.HasOne("CapitalEuropeiaGuarda.Models.Hoteis", "Hoteis")
                        .WithMany("PontoInteressePorHoteis")
                        .HasForeignKey("HoteisId");

                    b.HasOne("CapitalEuropeiaGuarda.Models.PontoInteresse", "PontoInteresse")
                        .WithMany("HoteisPorPontoInteresse")
                        .HasForeignKey("PontoInteresseId");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.ReservaExcursao", b =>
                {
                    b.HasOne("CapitalEuropeiaGuarda.Models.Turista", "Turista")
                        .WithMany("reservaexcursoes")
                        .HasForeignKey("TuristaId");
                });

            modelBuilder.Entity("CapitalEuropeiaGuarda.Models.Veiculo", b =>
                {
                    b.HasOne("CapitalEuropeiaGuarda.Models.Empresaaluguer", null)
                        .WithMany("Veiculo")
                        .HasForeignKey("empresaaluguerId");
                });
#pragma warning restore 612, 618
        }
    }
}
