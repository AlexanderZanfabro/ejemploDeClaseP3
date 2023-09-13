using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AutoresPublicacionesFavs_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorPublicacion1",
                columns: table => new
                {
                    MisAutoresFansId = table.Column<int>(type: "int", nullable: false),
                    MisPublicacionesFavoritasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorPublicacion1", x => new { x.MisAutoresFansId, x.MisPublicacionesFavoritasId });
                    table.ForeignKey(
                        name: "FK_AutorPublicacion1_Autores_MisAutoresFansId",
                        column: x => x.MisAutoresFansId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorPublicacion1_Publicaciones_MisPublicacionesFavoritasId",
                        column: x => x.MisPublicacionesFavoritasId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorPublicacion1_MisPublicacionesFavoritasId",
                table: "AutorPublicacion1",
                column: "MisPublicacionesFavoritasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorPublicacion1");
        }
    }
}
