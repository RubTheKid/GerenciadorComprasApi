using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorComprasApi.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AuthMigrationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30280c3d-1370-4704-9f5e-563f0375c173",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c29442a-3701-4be8-99bd-68db0ee13c95", "AQAAAAIAAYagAAAAEOeVIX376FQgzsl7gqTGHYe8W3oeLfMvjStWhGylftYXbkDp7xrvqQMCJzIYzy872w==", "69d73d90-5774-4249-b77a-25aba6c8e634" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30280c3d-1370-4704-9f5e-563f0375c173",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "114c6e9a-b684-4d50-b302-7ee34affd750", "AQAAAAIAAYagAAAAEFyZBL5GAiqOytWKgf2JC1Rq/B/z+buWXZOcXflBQJB+G83e+dytATELM/aJsj87bA==", "c3d73438-c440-4c42-970c-040c2be52cbe" });
        }
    }
}
