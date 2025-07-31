using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Game> Games { get; set; }
    public DbSet<Feature> Features { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasIndex(g => g.Slug)
            .IsUnique();

        modelBuilder.Entity<Game>()
            .Property(g => g.Title)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Feature>()
            .Property(f => f.Name)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Game>()
            .HasMany(g => g.Categories)
            .WithMany(c => c.Games);

        modelBuilder.Entity<Game>()
            .HasMany(g => g.Features)
            .WithMany();


        // Seed data
        var categoryArcade = new Category { Id = 1, Name = "Arcade" };
        var categoryRpg = new Category { Id = 2, Name = "Role-Playing Game" };
        var brickBreaker = new Game
        {
            Id = 1,
            Title = "Brick Breaker",
            Slug = "brick-breaker",
            Description = "Control your paddle and destroy all the blocks!",
            DetailedDescription = "Brick Breaker is a modern Unity-based arcade game featuring grid-based level design, modular block behaviors (explode, reflect, slow, move). Your job is to destroy all the block and obtain highest score.",
            WebGLPath = "/games/reflect/index.html",
            CoverImagePath = "/images/games/brick_breaker_img_cover.jpg",
        };

        var proceduralRpg = new Game
        {
            Id = 2,
            Title = "Procedural Rpg",
            Slug = "rpg-procedural",
            Description = "Fight monsters and obtain orbs to win!",
            DetailedDescription = "The player is thrown into a generated world with the main objective of collecting all missing keys to finish the game. Each key is located in a different biome, and while biomes can repeat, each contains exactly one key. The difficulty varies by biome and its enemies, making each playthrough more variable as the player explores the world.",
            WebGLPath = "/games/rpg/index.html",
            CoverImagePath = "/images/games/rpg_img_cover.jpg",
        };

        modelBuilder.Entity<Category>().HasData(categoryArcade);
        modelBuilder.Entity<Game>().HasData(brickBreaker);

        modelBuilder.Entity<Category>().HasData(categoryRpg);
        modelBuilder.Entity<Game>().HasData(proceduralRpg);
    }
}
