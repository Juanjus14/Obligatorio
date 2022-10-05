using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.LogicaAccesoDatos.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paises_CodigoPais_CodigoISO_Alfa3",
                table: "Paises");

            migrationBuilder.DropForeignKey(
                name: "FK_Paises_ImagenPais_ImagenURL",
                table: "Paises");

            migrationBuilder.DropForeignKey(
                name: "FK_Selecciones_PersonaContacto_ContactoNombre",
                table: "Selecciones");

            migrationBuilder.DropTable(
                name: "CodigoPais");

            migrationBuilder.DropTable(
                name: "ImagenPais");

            migrationBuilder.DropTable(
                name: "InfoSeleccionPartido");

            migrationBuilder.DropTable(
                name: "PersonaContacto");

            migrationBuilder.DropIndex(
                name: "IX_Selecciones_ContactoNombre",
                table: "Selecciones");

            migrationBuilder.DropIndex(
                name: "IX_Paises_CodigoISO_Alfa3",
                table: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Paises_ImagenURL",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "ContactoNombre",
                table: "Selecciones");

            migrationBuilder.DropColumn(
                name: "CodigoISO_Alfa3",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "ImagenURL",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Paises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactoNombre",
                table: "Selecciones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoISO_Alfa3",
                table: "Paises",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenURL",
                table: "Paises",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CodigoPais",
                columns: table => new
                {
                    CodigoISO_Alfa3 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoPais", x => x.CodigoISO_Alfa3);
                });

            migrationBuilder.CreateTable(
                name: "ImagenPais",
                columns: table => new
                {
                    URL = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenPais", x => x.URL);
                });

            migrationBuilder.CreateTable(
                name: "InfoSeleccionPartido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amarillas = table.Column<int>(type: "int", nullable: false),
                    Goles = table.Column<int>(type: "int", nullable: false),
                    PartidoId = table.Column<int>(type: "int", nullable: true),
                    RojasAcumuladas = table.Column<int>(type: "int", nullable: false),
                    RojasDirectas = table.Column<int>(type: "int", nullable: false),
                    SeleccionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoSeleccionPartido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoSeleccionPartido_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoSeleccionPartido_Selecciones_SeleccionId",
                        column: x => x.SeleccionId,
                        principalTable: "Selecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonaContacto",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaContacto", x => x.Nombre);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_ContactoNombre",
                table: "Selecciones",
                column: "ContactoNombre");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_CodigoISO_Alfa3",
                table: "Paises",
                column: "CodigoISO_Alfa3");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_ImagenURL",
                table: "Paises",
                column: "ImagenURL");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeleccionPartido_PartidoId",
                table: "InfoSeleccionPartido",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeleccionPartido_SeleccionId",
                table: "InfoSeleccionPartido",
                column: "SeleccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_CodigoPais_CodigoISO_Alfa3",
                table: "Paises",
                column: "CodigoISO_Alfa3",
                principalTable: "CodigoPais",
                principalColumn: "CodigoISO_Alfa3",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_ImagenPais_ImagenURL",
                table: "Paises",
                column: "ImagenURL",
                principalTable: "ImagenPais",
                principalColumn: "URL",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Selecciones_PersonaContacto_ContactoNombre",
                table: "Selecciones",
                column: "ContactoNombre",
                principalTable: "PersonaContacto",
                principalColumn: "Nombre",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
