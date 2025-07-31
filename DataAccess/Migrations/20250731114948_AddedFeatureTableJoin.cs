using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedFeatureTableJoin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureGame");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2u);

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
                    { 2u, "ProceduralGeneration" }
                });

            migrationBuilder.InsertData(
                table: "GameFeature",
                columns: new[] { "FeaturesId", "GamesId" },
                values: new object[,]
                {
                    { 1u, 1u },
                    { 1u, 2u },
                    { 2u, 2u }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameFeature_GamesId",
                table: "GameFeature",
                column: "GamesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameFeature");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2u);

            migrationBuilder.CreateTable(
                name: "FeatureGame",
                columns: table => new
                {
                    FeaturesId = table.Column<uint>(type: "INTEGER", nullable: false),
                    GameId = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureGame", x => new { x.FeaturesId, x.GameId });
                    table.ForeignKey(
                        name: "FK_FeatureGame_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1u, "Arcade" },
                    { 2u, "Role-Playing Game" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureGame_GameId",
                table: "FeatureGame",
                column: "GameId");
        }
    }
}
