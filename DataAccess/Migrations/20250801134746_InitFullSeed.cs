using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitFullSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DetailedDescription = table.Column<string>(type: "TEXT", nullable: false),
                    WebGLPath = table.Column<string>(type: "TEXT", nullable: false),
                    CoverImagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryGame",
                columns: table => new
                {
                    CategoriesId = table.Column<uint>(type: "INTEGER", nullable: false),
                    GamesId = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGame", x => new { x.CategoriesId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_CategoryGame_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameFeature",
                columns: table => new
                {
                    FeaturesId = table.Column<uint>(type: "INTEGER", nullable: false),
                    GamesId = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFeature", x => new { x.FeaturesId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_GameFeature_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameFeature_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1u, "ObjectPooling" },
                    { 2u, "ProceduralGeneration" },
                    { 3u, "PerlinNoise" },
                    { 4u, "SaveSystemJSON" },
                    { 5u, "PathfindingAI" },
                    { 6u, "Chunks" },
                    { 7u, "NavMesh" },
                    { 8u, "AnimationSystem" },
                    { 9u, "WorldGeneration" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CoverImagePath", "Description", "DetailedDescription", "Slug", "Title", "WebGLPath" },
                values: new object[,]
                {
                    { 1u, "/images/games/brick_breaker_img_cover.jpg", "Control your paddle and destroy all the blocks!", "Brick Breaker is a modern Unity-based arcade game featuring grid-based level design, modular block behaviors (explode, reflect, slow, move). Your job is to destroy all the blocks and obtain the highest score.", "brick-breaker", "Brick Breaker", "https://play.unity.com/en/games/865b6456-69f2-4610-8c13-06cb84d4357a/brick-breakerwebbuild" },
                    { 2u, "/images/games/rpg_img_cover.jpg", "Fight monsters and obtain orbs to win!", "The player is thrown into a generated world with the main objective of collecting all missing keys to finish the game. Each key is located in a different biome, and while biomes can repeat, each contains exactly one key. The difficulty varies by biome and its enemies, making each playthrough more variable as the player explores the world.", "rpg-procedural", "Procedural Rpg", "https://play.unity.com/en/games/ce0cc483-47a9-4977-af17-0942d6862e83/procedural-rpg" }
                });

            migrationBuilder.InsertData(
                table: "GameFeature",
                columns: new[] { "FeaturesId", "GamesId" },
                values: new object[,]
                {
                    { 1u, 1u },
                    { 1u, 2u },
                    { 2u, 2u },
                    { 3u, 2u },
                    { 4u, 2u },
                    { 5u, 2u },
                    { 6u, 2u },
                    { 7u, 2u },
                    { 8u, 2u },
                    { 9u, 2u }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGame_GamesId",
                table: "CategoryGame",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameFeature_GamesId",
                table: "GameFeature",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Slug",
                table: "Games",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryGame");

            migrationBuilder.DropTable(
                name: "GameFeature");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
