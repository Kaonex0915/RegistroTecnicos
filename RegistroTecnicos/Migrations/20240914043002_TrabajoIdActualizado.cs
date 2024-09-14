using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class TrabajoIdActualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientesId",
                table: "Trabajos",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "TrabajosId",
                table: "Trabajos",
                newName: "TrabajoId");

            migrationBuilder.RenameColumn(
                name: "ClientesId",
                table: "Clientes",
                newName: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Trabajos",
                newName: "ClientesId");

            migrationBuilder.RenameColumn(
                name: "TrabajoId",
                table: "Trabajos",
                newName: "TrabajosId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Clientes",
                newName: "ClientesId");
        }
    }
}
