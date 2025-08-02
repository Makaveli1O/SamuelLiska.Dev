using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Game> Games { get; set; }
    public DbSet<Feature> Features { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Game entity configuration
        modelBuilder.Entity<Game>()
            .HasIndex(g => g.Slug)
            .IsUnique();

        modelBuilder.Entity<Game>()
            .Property(g => g.Title)
            .HasMaxLength(100)
            .IsRequired();

        // Feature entity configuration
        modelBuilder.Entity<Feature>()
            .Property(f => f.Name)
            .HasMaxLength(50)
            .IsRequired();

        // Many-to-Many: Game <-> Feature
        modelBuilder.Entity<Game>()
            .HasMany(g => g.Features)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "GameFeature",
                j => j.HasOne<Feature>().WithMany().HasForeignKey("FeaturesId"),
                j => j.HasOne<Game>().WithMany().HasForeignKey("GamesId")
            );

        // =======================
        // Seed Data
        // =======================

        // Games
        var brickBreaker = new Game
        {
            Id = 1,
            Title = "Brick Breaker",
            Slug = "brick-breaker",
            Description = "Control your paddle and destroy all the blocks!",
            DetailedDescription = "Brick Breaker is a modern Unity-based arcade game featuring grid-based level design, modular block behaviors (explode, reflect, slow, move). Your job is to destroy all the blocks and obtain the highest score.",
            WebGLPath = "https://play.unity.com/en/games/865b6456-69f2-4610-8c13-06cb84d4357a/brick-breakerwebbuild",
            CoverImagePath = "/images/games/brick_breaker_img_cover.jpg"
        };

        var proceduralRpg = new Game
        {
            Id = 2,
            Title = "Procedural Rpg",
            Slug = "rpg-procedural",
            Description = "Fight monsters and obtain orbs to win!",
            DetailedDescription = "The player is thrown into a generated world with the main objective of collecting all missing keys to finish the game. Each key is located in a different biome, and while biomes can repeat, each contains exactly one key. The difficulty varies by biome and its enemies, making each playthrough more variable as the player explores the world.",
            WebGLPath = "https://play.unity.com/en/games/d19c9865-c548-4c03-91ab-bf96491eeefc/procedural-rpg",
            CoverImagePath = "/images/games/rpg_img_cover.jpg"
        };

        // Features
        var featureObjectPooling     = new Feature { Id = 1, Name = "ObjectPooling" };
        var featureProcedural        = new Feature { Id = 2, Name = "ProceduralGeneration" };
        var featurePerlinNoise       = new Feature { Id = 3, Name = "PerlinNoise" };
        var featureSaveSystem        = new Feature { Id = 4, Name = "SaveSystemJSON" };
        var featureAI                = new Feature { Id = 5, Name = "PathfindingAI" };
        var featureChunks            = new Feature { Id = 6, Name = "Chunks" };
        var featureNavMesh           = new Feature { Id = 7, Name = "NavMesh" };
        var featureAnimationSystem   = new Feature { Id = 8, Name = "AnimationSystem" };
        var featureWorldGeneration   = new Feature { Id = 9, Name = "WorldGeneration" };

        // Seed main tables
        modelBuilder.Entity<Game>().HasData(brickBreaker, proceduralRpg);
        modelBuilder.Entity<Feature>().HasData(
            featureObjectPooling,
            featureProcedural,
            featurePerlinNoise,
            featureSaveSystem,
            featureAI,
            featureChunks,
            featureNavMesh,
            featureAnimationSystem,
            featureWorldGeneration
        );

        // Seed many-to-many join table
        modelBuilder.Entity("GameFeature").HasData(
            new { GamesId = 1u, FeaturesId = 1u }, // BrickBreaker -> ObjectPooling
            new { GamesId = 2u, FeaturesId = 1u }, // ProceduralRpg -> ObjectPooling
            new { GamesId = 2u, FeaturesId = 2u },
            new { GamesId = 2u, FeaturesId = 3u },
            new { GamesId = 2u, FeaturesId = 4u },
            new { GamesId = 2u, FeaturesId = 5u },
            new { GamesId = 2u, FeaturesId = 6u },
            new { GamesId = 2u, FeaturesId = 7u },
            new { GamesId = 2u, FeaturesId = 8u },
            new { GamesId = 2u, FeaturesId = 9u }
        );
    }

}
