using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorComprasApi.Migrations
{
    /// <inheritdoc />
    public partial class fixes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Empresas");

            migrationBuilder.AddColumn<string>(
                name: "CodigoServico",
                table: "Servicos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Gtin",
                table: "Produtos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos",
                column: "CodigoServico");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Gtin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas",
                column: "Cnpj");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "CodigoServico",
                table: "Servicos");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Gtin",
                table: "Produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Empresas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas",
                column: "Id");
        }
    }
}
