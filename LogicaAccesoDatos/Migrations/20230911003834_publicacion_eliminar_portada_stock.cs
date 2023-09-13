using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class publicacion_eliminar_portada_stock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenPortada",
                table: "Publicaciones");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Publicaciones");

            migrationBuilder.DropColumn(
                name: "StockMinimo",
                table: "Publicaciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenPortada",
                table: "Publicaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Publicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockMinimo",
                table: "Publicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
