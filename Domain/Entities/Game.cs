namespace Domain.Entities;

public class Game
{
    public uint Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string WebGLPath { get; set; } = string.Empty;
    public string CoverImagePath { get; set; } = string.Empty;

    public ICollection<Category> Categories { get; set; } = new List<Category>();
}
