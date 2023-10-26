using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorComprasApi.Migrations
{
    /// <inheritdoc />
    public partial class fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaProduto");

            migrationBuilder.DropTable(
                name: "EmpresaServico");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "EmpresaProduto",
                columns: table => new
                {
                    EmpresasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaProduto", x => new { x.EmpresasId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_EmpresaProduto_Empresas_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaProduto_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaServico",
                columns: table => new
                {
                    EmpresasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaServico", x => new { x.EmpresasId, x.ServicosId });
                    table.ForeignKey(
                        name: "FK_EmpresaServico_Empresas_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaServico_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaProduto_ProdutosId",
                table: "EmpresaProduto",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaServico_ServicosId",
                table: "EmpresaServico",
                column: "ServicosId");
        }
    }
}
