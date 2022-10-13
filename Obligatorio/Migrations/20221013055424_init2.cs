using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligatorio.LogicaAccesoDatos.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Codigo_CodigoISO_Alfa3",
                table: "Paises",
                newName: "CodigoISO_CodigoISO_Alfa3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoISO_CodigoISO_Alfa3",
                table: "Paises",
                newName: "Codigo_CodigoISO_Alfa3");
        }
    }
}
