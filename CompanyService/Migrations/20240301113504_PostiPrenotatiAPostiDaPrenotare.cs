using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyService.Migrations
{
    /// <inheritdoc />
    public partial class PostiPrenotatiAPostiDaPrenotare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostiPrenotati",
                table: "Biglietti",
                newName: "PostiDaPrenotare");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostiDaPrenotare",
                table: "Biglietti",
                newName: "PostiPrenotati");
        }
    }
}
