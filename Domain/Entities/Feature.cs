namespace Domain.Entities;

// This class describes feature that was used in developed game to higlight encountered
// challenges.
public class Feature : IEntity
{
    public uint Id { get; set; }
    public string Name { get; set; } = string.Empty;
}