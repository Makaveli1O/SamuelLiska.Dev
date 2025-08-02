using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2u,
                column: "WebGLPath",
                value: "https://play.unity.com/en/games/d19c9865-c548-4c03-91ab-bf96491eeefc/procedural-rpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2u,
                column: "WebGLPath",
                value: "https://play.unity.com/en/games/ce0cc483-47a9-4977-af17-0942d6862e83/procedural-rpg");
        }
    }
}
