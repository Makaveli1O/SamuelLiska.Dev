namespace BusinessLayer.Dto.Game;
public class GameCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DetailedDescription { get; set; } = string.Empty;
    public string WebGLPath { get; set; } = string.Empty;
    public string CoverImagePath { get; set; } = string.Empty;
}