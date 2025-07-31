using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedDetailedDescriptionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailedDescription",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1u,
                column: "DetailedDescription",
                value: "Brick Breaker is a modern Unity-based arcade game featuring grid-based level design, modular block behaviors (explode, reflect, slow, move). Your job is to destroy all the block and obtain highest score.");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2u,
                column: "DetailedDescription",
                value: "The player is thrown into a generated world with the main objective of collecting all missing keys to finish the game. Each key is located in a different biome, and while biomes can repeat, each contains exactly one key. The difficulty varies by biome and its enemies, making each playthrough more variable as the player explores the world.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedDescription",
                table: "Games");
        }
    }
}
