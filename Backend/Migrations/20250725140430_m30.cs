using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class m30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestCarreras");

            migrationBuilder.CreateTable(
                name: "CarreraTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Test_id = table.Column<int>(type: "int", nullable: true),
                    Carrera_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarreraTests_Carreras_Carrera_id",
                        column: x => x.Carrera_id,
                        principalTable: "Carreras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarreraTests_Tests_Test_id",
                        column: x => x.Test_id,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarreraTests_Carrera_id",
                table: "CarreraTests",
                column: "Carrera_id");

            migrationBuilder.CreateIndex(
                name: "IX_CarreraTests_Test_id",
                table: "CarreraTests",
                column: "Test_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarreraTests");

            migrationBuilder.CreateTable(
                name: "TestCarreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carrera_id = table.Column<int>(type: "int", nullable: true),
                    Test_id = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_TestCarreras_Carrera_id",
                table: "TestCarreras",
                column: "Carrera_id");

            migrationBuilder.CreateIndex(
                name: "IX_TestCarreras_Test_id",
                table: "TestCarreras",
                column: "Test_id");
        }
    }
}
