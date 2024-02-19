using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyService.Migrations
{
    /// <inheritdoc />
    public partial class aggiuntoentitàaereoeflotta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flotte",
                columns: table => new
                {
                    FlottaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flotte", x => x.FlottaId);
                });

            migrationBuilder.CreateTable(
                name: "Aerei",
                columns: table => new
                {
                    AereoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceAereo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDiPosti = table.Column<long>(type: "bigint", nullable: false),
                    FlottaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerei", x => x.AereoId);
                    table.ForeignKey(
                        name: "FK_Aerei_Flotte_FlottaId",
                        column: x => x.FlottaId,
                        principalTable: "Flotte",
                        principalColumn: "FlottaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aerei_FlottaId",
                table: "Aerei",
                column: "FlottaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aerei");

            migrationBuilder.DropTable(
                name: "Flotte");
        }
    }
}
