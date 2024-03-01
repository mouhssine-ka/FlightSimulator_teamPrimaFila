﻿// <auto-generated />
using System;
using CompanyService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyService.Migrations
{
    [DbContext(typeof(FlightSimulatorDBContext))]
    [Migration("20240301113504_PostiPrenotatiAPostiDaPrenotare")]
    partial class PostiPrenotatiAPostiDaPrenotare
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanyService.Aereo", b =>
                {
                    b.Property<long>("AereoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AereoId"));

                    b.Property<string>("CodiceAereo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Colore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FlottaId")
                        .HasColumnType("bigint");

                    b.Property<long>("NumeroDiPosti")
                        .HasColumnType("bigint");

                    b.HasKey("AereoId");

                    b.HasIndex("FlottaId");

                    b.ToTable("Aerei");
                });

            modelBuilder.Entity("CompanyService.Biglietto", b =>
                {
                    b.Property<int>("BigliettoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BigliettoId"));

                    b.Property<DateTime>("DataAcquisto")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ImportoTotale")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PostiDaPrenotare")
                        .HasColumnType("int");

                    b.Property<long>("VoloId")
                        .HasColumnType("bigint");

                    b.HasKey("BigliettoId");

                    b.HasIndex("VoloId");

                    b.ToTable("Biglietti");
                });

            modelBuilder.Entity("CompanyService.Flotta", b =>
                {
                    b.Property<long>("FlottaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FlottaId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlottaId");

                    b.ToTable("Flotte");
                });

            modelBuilder.Entity("CompanyService.Volo", b =>
                {
                    b.Property<long>("VoloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VoloId"));

                    b.Property<long>("AereoId")
                        .HasColumnType("bigint");

                    b.Property<string>("CittaArrivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CittaPartenza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CostoDelPosto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrarioArrivo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrarioPartenza")
                        .HasColumnType("datetime2");

                    b.Property<long>("PostiRimanenti")
                        .HasColumnType("bigint");

                    b.HasKey("VoloId");

                    b.HasIndex("AereoId");

                    b.ToTable("Voli");
                });

            modelBuilder.Entity("Crew", b =>
                {
                    b.Property<long>("CrewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CrewId"));

                    b.Property<long>("Age")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrewId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("CompanyService.Aereo", b =>
                {
                    b.HasOne("CompanyService.Flotta", null)
                        .WithMany("Aerei")
                        .HasForeignKey("FlottaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyService.Biglietto", b =>
                {
                    b.HasOne("CompanyService.Volo", "Volo")
                        .WithMany()
                        .HasForeignKey("VoloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Volo");
                });

            modelBuilder.Entity("CompanyService.Volo", b =>
                {
                    b.HasOne("CompanyService.Aereo", "Aereo")
                        .WithMany()
                        .HasForeignKey("AereoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aereo");
                });

            modelBuilder.Entity("CompanyService.Flotta", b =>
                {
                    b.Navigation("Aerei");
                });
#pragma warning restore 612, 618
        }
    }
}
