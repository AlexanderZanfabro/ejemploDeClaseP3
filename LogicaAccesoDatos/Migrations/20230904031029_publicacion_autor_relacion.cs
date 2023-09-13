using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class publicacion_autor_relacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Publicaciones_PublicacionId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_PublicacionId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "PublicacionId",
                table: "Autores");

            migrationBuilder.CreateTable(
                name: "AutorPublicacion",
                columns: table => new
                {
                    AutoresId = table.Column<int>(type: "int", nullable: false),
                    MisPublicacionesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorPublicacion", x => new { x.AutoresId, x.MisPublicacionesId });
                    table.ForeignKey(
                        name: "FK_AutorPublicacion_Autores_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorPublicacion_Publicaciones_MisPublicacionesId",
                        column: x => x.MisPublicacionesId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorPublicacion_MisPublicacionesId",
                table: "AutorPublicacion",
                column: "MisPublicacionesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorPublicacion");

            migrationBuilder.AddColumn<int>(
                name: "PublicacionId",
                table: "Autores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_PublicacionId",
                table: "Autores",
                column: "PublicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Publicaciones_PublicacionId",
                table: "Autores",
                column: "PublicacionId",
                principalTable: "Publicaciones",
                principalColumn: "Id");
        }
    }
}
