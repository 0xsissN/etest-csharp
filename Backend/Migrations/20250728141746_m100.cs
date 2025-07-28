using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class m100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha_Nacimiento",
                table: "Estudiantes",
                newName: "FechaNacimiento");

            migrationBuilder.RenameColumn(
                name: "Apellido_Paterno",
                table: "Estudiantes",
                newName: "ApellidoPaterno");

            migrationBuilder.RenameColumn(
                name: "Apellido_Materno",
                table: "Estudiantes",
                newName: "ApellidoMaterno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Estudiantes",
                newName: "Fecha_Nacimiento");

            migrationBuilder.RenameColumn(
                name: "ApellidoPaterno",
                table: "Estudiantes",
                newName: "Apellido_Paterno");

            migrationBuilder.RenameColumn(
                name: "ApellidoMaterno",
                table: "Estudiantes",
                newName: "Apellido_Materno");
        }
    }
}
