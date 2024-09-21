using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class CambioTiempo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Prioridades");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tiempo",
                table: "Prioridades",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tiempo",
                table: "Prioridades");

            migrationBuilder.AddColumn<int>(
                name: "Fecha",
                table: "Prioridades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
