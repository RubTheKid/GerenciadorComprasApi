using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorComprasApi.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gtin = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstoqueDisponivel = table.Column<int>(type: "int", nullable: true),
                    CotaMinima = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrazoEntrega = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoId);
                });

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
                    ServicosServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaServico", x => new { x.EmpresasId, x.ServicosServicoId });
                    table.ForeignKey(
                        name: "FK_EmpresaServico_Empresas_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaServico_Servicos_ServicosServicoId",
                        column: x => x.ServicosServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaProduto_ProdutosId",
                table: "EmpresaProduto",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaServico_ServicosServicoId",
                table: "EmpresaServico",
                column: "ServicosServicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaProduto");

            migrationBuilder.DropTable(
                name: "EmpresaServico");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Servicos");
        }
    }
}
