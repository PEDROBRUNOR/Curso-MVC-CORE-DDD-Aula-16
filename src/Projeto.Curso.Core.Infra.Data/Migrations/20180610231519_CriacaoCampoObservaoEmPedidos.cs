using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Curso.Core.Infra.Data.Migrations
{
    public partial class CriacaoCampoObservaoEmPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Pedidos",
                type: "varchar(4000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Pedidos");
        }
    }
}
