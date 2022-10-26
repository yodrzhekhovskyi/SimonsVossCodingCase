namespace SimonsVossCodingCase.Repositories.Models;

public class Medium
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid GroupId { get; set; }
    public MediumType Type { get; set; }
    public string Owner { get; set; } = string.Empty;

    public string SerialNumber { get; set; } = string.Empty;
}

public enum MediumType
{
    Card,
    TransponderWithCardInlay,
    Transponder
}