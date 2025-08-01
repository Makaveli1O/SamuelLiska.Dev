using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BreakerWebPathMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1u,
                column: "WebGLPath",
                value: "https://play.unity.com/en/games/865b6456-69f2-4610-8c13-06cb84d4357a/brick-breakerwebbuild");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1u,
                column: "WebGLPath",
                value: "/games/reflect/index.html");
        }
    }
}
