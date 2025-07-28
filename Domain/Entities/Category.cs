namespace Domain.Entities;

public class Category
{
    public uint Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Game> Games { get; set; } = new List<Game>();
}
