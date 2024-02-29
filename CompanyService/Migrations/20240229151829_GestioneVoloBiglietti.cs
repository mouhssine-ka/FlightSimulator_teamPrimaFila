using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyService.Migrations
{
    /// <inheritdoc />
    public partial class GestioneVoloBiglietti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voli",
                columns: table => new
                {
                    VoloId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AereoId = table.Column<long>(type: "bigint", nullable: false),
                    PostiRimanenti = table.Column<long>(type: "bigint", nullable: false),
                    CostoDelPosto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CittaPartenza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CittaArrivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrarioPartenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrarioArrivo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voli", x => x.VoloId);
                    table.ForeignKey(
                        name: "FK_Voli_Aerei_AereoId",
                        column: x => x.AereoId,
                        principalTable: "Aerei",
                        principalColumn: "AereoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biglietti",
                columns: table => new
                {
                    BigliettoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoloId = table.Column<long>(type: "bigint", nullable: false),
                    PostiPrenotati = table.Column<int>(type: "int", nullable: false),
                    ImportoTotale = table.Column<double>(type: "float", nullable: false),
                    DataAcquisto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biglietti", x => x.BigliettoId);
                    table.ForeignKey(
                        name: "FK_Biglietti_Voli_VoloId",
                        column: x => x.VoloId,
                        principalTable: "Voli",
                        principalColumn: "VoloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biglietti_VoloId",
                table: "Biglietti",
                column: "VoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Voli_AereoId",
                table: "Voli",
                column: "AereoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biglietti");

            migrationBuilder.DropTable(
                name: "Voli");
        }
    }
}
