﻿// <auto-generated />
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
    [Migration("20240216103024_aggiunto entità aereo e flotta")]
    partial class aggiuntoentitàaereoeflotta
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

            modelBuilder.Entity("CompanyService.Flotta", b =>
                {
                    b.Property<long>("FlottaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FlottaId"));

                    b.HasKey("FlottaId");

                    b.ToTable("Flotte");
                });

            modelBuilder.Entity("CompanyService.Aereo", b =>
                {
                    b.HasOne("CompanyService.Flotta", null)
                        .WithMany("Aerei")
                        .HasForeignKey("FlottaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyService.Flotta", b =>
                {
                    b.Navigation("Aerei");
                });
#pragma warning restore 612, 618
        }
    }
}
