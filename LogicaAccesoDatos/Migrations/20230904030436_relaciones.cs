using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioSugerido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadPaginas = table.Column<int>(type: "int", nullable: false),
                    ImagenPortada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false),
                    MiTemaId = table.Column<int>(type: "int", nullable: false),
                    MiEditorialId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<long>(type: "bigint", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Anho = table.Column<int>(type: "int", nullable: true),
                    TablaContenido = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Editoriales_MiEditorialId",
                        column: x => x.MiEditorialId,
                        principalTable: "Editoriales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Temas_MiTemaId",
                        column: x => x.MiTemaId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDefuncion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MiDireccion_Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiDireccion_NumeroPuerta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autores_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Biografia",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biografia", x => x.AutorId);
                    table.ForeignKey(
                        name: "FK_Biografia_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    CodigoArea = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => new { x.AutorId, x.CodigoArea, x.Numero });
                    table.ForeignKey(
                        name: "FK_Telefono_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_PublicacionId",
                table: "Autores",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_MiEditorialId",
                table: "Publicaciones",
                column: "MiEditorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_MiTemaId",
                table: "Publicaciones",
                column: "MiTemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biografia");

            migrationBuilder.DropTable(
                name: "Telefono");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Editoriales");
        }
    }
}
