using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroVeiculo.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeColaborador = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    enderecoSolicitante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Chamados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeSolicitante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    enderecoSolicitante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cepSolicitante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    placaVeiculo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dataAberturaChamado = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    Colaboradorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamados", x => x.id);
                    table.ForeignKey(
                        name: "FK_Chamados_Colaboradores_Colaboradorid",
                        column: x => x.Colaboradorid,
                        principalTable: "Colaboradores",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_Colaboradorid",
                table: "Chamados",
                column: "Colaboradorid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamados");

            migrationBuilder.DropTable(
                name: "Colaboradores");
        }
    }
}
