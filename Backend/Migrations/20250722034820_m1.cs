using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aptitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aptitudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colegios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colegios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ci = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Paterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Materno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aptitud_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carreras_Aptitudes_Aptitud_id",
                        column: x => x.Aptitud_id,
                        principalTable: "Aptitudes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estudiante_ci = table.Column<int>(type: "int", nullable: true),
                    Colegio_id = table.Column<int>(type: "int", nullable: true),
                    Curso_id = table.Column<int>(type: "int", nullable: true),
                    Usuario_id = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Colegios_Colegio_id",
                        column: x => x.Colegio_id,
                        principalTable: "Colegios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_Cursos_Curso_id",
                        column: x => x.Curso_id,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_Estudiantes_Estudiante_ci",
                        column: x => x.Estudiante_ci,
                        principalTable: "Estudiantes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_Usuarios_Usuario_id",
                        column: x => x.Usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestCarreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Test_id = table.Column<int>(type: "int", nullable: true),
                    Carrera_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCarreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCarreras_Carreras_Carrera_id",
                        column: x => x.Carrera_id,
                        principalTable: "Carreras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestCarreras_Tests_Test_id",
                        column: x => x.Test_id,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_Aptitud_id",
                table: "Carreras",
                column: "Aptitud_id");

            migrationBuilder.CreateIndex(
                name: "IX_TestCarreras_Carrera_id",
                table: "TestCarreras",
                column: "Carrera_id");

            migrationBuilder.CreateIndex(
                name: "IX_TestCarreras_Test_id",
                table: "TestCarreras",
                column: "Test_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_Colegio_id",
                table: "Tests",
                column: "Colegio_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_Curso_id",
                table: "Tests",
                column: "Curso_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_Estudiante_ci",
                table: "Tests",
                column: "Estudiante_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_Usuario_id",
                table: "Tests",
                column: "Usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestCarreras");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Aptitudes");

            migrationBuilder.DropTable(
                name: "Colegios");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
