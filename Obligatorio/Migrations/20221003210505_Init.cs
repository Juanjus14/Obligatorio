using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.LogicaAccesoDatos.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodigoPais",
                columns: table => new
                {
                    CodigoISO_Alfa3 = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoPais", x => x.CodigoISO_Alfa3);
                });

            migrationBuilder.CreateTable(
                name: "ImagenPais",
                columns: table => new
                {
                    URL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenPais", x => x.URL);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonaContacto",
                columns: table => new
                {
                    Nombre = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaContacto", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    CodigoISO_Alfa3 = table.Column<string>(nullable: true),
                    PBI = table.Column<double>(nullable: false),
                    Poblacion = table.Column<int>(nullable: false),
                    ImagenURL = table.Column<string>(nullable: true),
                    Region = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paises_CodigoPais_CodigoISO_Alfa3",
                        column: x => x.CodigoISO_Alfa3,
                        principalTable: "CodigoPais",
                        principalColumn: "CodigoISO_Alfa3",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paises_ImagenPais_ImagenURL",
                        column: x => x.ImagenURL,
                        principalTable: "ImagenPais",
                        principalColumn: "URL",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Selecciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(nullable: false),
                    ContactoNombre = table.Column<string>(nullable: true),
                    CantidadApostadores = table.Column<int>(nullable: false),
                    Grupo = table.Column<int>(nullable: false),
                    Puntuacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Selecciones_PersonaContacto_ContactoNombre",
                        column: x => x.ContactoNombre,
                        principalTable: "PersonaContacto",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selecciones_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoSeleccionPartido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidoId = table.Column<int>(nullable: true),
                    SeleccionId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoSeleccionPartido_Selecciones_SeleccionId",
                        column: x => x.SeleccionId,
                        principalTable: "Selecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeleccionPartido_PartidoId",
                table: "InfoSeleccionPartido",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeleccionPartido_SeleccionId",
                table: "InfoSeleccionPartido",
                column: "SeleccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_CodigoISO_Alfa3",
                table: "Paises",
                column: "CodigoISO_Alfa3");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_ImagenURL",
                table: "Paises",
                column: "ImagenURL");

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_ContactoNombre",
                table: "Selecciones",
                column: "ContactoNombre");

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_PaisId",
                table: "Selecciones",
                column: "PaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoSeleccionPartido");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Selecciones");

            migrationBuilder.DropTable(
                name: "PersonaContacto");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "CodigoPais");

            migrationBuilder.DropTable(
                name: "ImagenPais");
        }
    }
}
