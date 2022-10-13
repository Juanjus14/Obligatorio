using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.LogicaAccesoDatos.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contacto_Email",
                table: "Selecciones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacto_Nombre",
                table: "Selecciones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacto_Telefono",
                table: "Selecciones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo_CodigoISO_Alfa3",
                table: "Paises",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagen_URL",
                table: "Paises",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre_Nombre",
                table: "Paises",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InfoSeleccionPartido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidoId = table.Column<int>(nullable: false),
                    SeleccionId = table.Column<int>(nullable: false),
                    Goles = table.Column<int>(nullable: false),
                    RojasDirectas = table.Column<int>(nullable: false),
                    RojasAcumuladas = table.Column<int>(nullable: false),
                    Amarillas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoSeleccionPartido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoSeleccionPartido_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoSeleccionPartido_Selecciones_SeleccionId",
                        column: x => x.SeleccionId,
                        principalTable: "Selecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeleccionPartido_PartidoId",
                table: "InfoSeleccionPartido",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeleccionPartido_SeleccionId",
                table: "InfoSeleccionPartido",
                column: "SeleccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoSeleccionPartido");

            migrationBuilder.DropColumn(
                name: "Contacto_Email",
                table: "Selecciones");

            migrationBuilder.DropColumn(
                name: "Contacto_Nombre",
                table: "Selecciones");

            migrationBuilder.DropColumn(
                name: "Contacto_Telefono",
                table: "Selecciones");

            migrationBuilder.DropColumn(
                name: "Codigo_CodigoISO_Alfa3",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Imagen_URL",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Nombre_Nombre",
                table: "Paises");
        }
    }
}
