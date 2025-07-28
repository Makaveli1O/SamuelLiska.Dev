using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Game> Games { get; set; }

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

        modelBuilder.Entity<Game>()
            .HasMany(g => g.Categories)
            .WithMany(c => c.Games);

        // Seed data
        var catPuzzle = new Category { Id = 1, Name = "Arcade" };
        var gameReflect = new Game
        {
            Id = 1,
            Title = "Brick Breaker",
            Slug = "brick-breaker",
            Description = "Control your paddle and destroy all the blocks!",
            WebGLPath = "/games/reflect/index.html",
            CoverImagePath = "/images/reflect.jpg",
        };
        modelBuilder.Entity<Category>().HasData(catPuzzle);
        modelBuilder.Entity<Game>().HasData(gameReflect);
    }
}
