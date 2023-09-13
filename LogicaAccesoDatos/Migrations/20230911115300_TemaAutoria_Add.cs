using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class TemaAutoria_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorTema",
                columns: table => new
                {
                    AutoresUsanTemaId = table.Column<int>(type: "int", nullable: false),
                    TemasAbordadosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorTema", x => new { x.AutoresUsanTemaId, x.TemasAbordadosId });
                    table.ForeignKey(
                        name: "FK_AutorTema_Autores_AutoresUsanTemaId",
                        column: x => x.AutoresUsanTemaId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorTema_Temas_TemasAbordadosId",
                        column: x => x.TemasAbordadosId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorTema_TemasAbordadosId",
                table: "AutorTema",
                column: "TemasAbordadosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorTema");
        }
    }
}
