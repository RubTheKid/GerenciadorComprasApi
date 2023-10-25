using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorComprasApi.Migrations
{
    /// <inheritdoc />
    public partial class GerenciadorUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaServico_Servicos_ServicosServicoId",
                table: "EmpresaServico");

            migrationBuilder.RenameColumn(
                name: "ServicoId",
                table: "Servicos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ServicosServicoId",
                table: "EmpresaServico",
                newName: "ServicosId");

            migrationBuilder.RenameIndex(
                name: "IX_EmpresaServico_ServicosServicoId",
                table: "EmpresaServico",
                newName: "IX_EmpresaServico_ServicosId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaServico_Servicos_ServicosId",
                table: "EmpresaServico",
                column: "ServicosId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaServico_Servicos_ServicosId",
                table: "EmpresaServico");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Servicos",
                newName: "ServicoId");

            migrationBuilder.RenameColumn(
                name: "ServicosId",
                table: "EmpresaServico",
                newName: "ServicosServicoId");

            migrationBuilder.RenameIndex(
                name: "IX_EmpresaServico_ServicosId",
                table: "EmpresaServico",
                newName: "IX_EmpresaServico_ServicosServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaServico_Servicos_ServicosServicoId",
                table: "EmpresaServico",
                column: "ServicosServicoId",
                principalTable: "Servicos",
                principalColumn: "ServicoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
