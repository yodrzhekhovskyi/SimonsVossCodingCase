namespace SimonsVossCodingCase.Repositories.Models;

public class Medium
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public MediumType MediumType { get; set; }
    public string Owner { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public enum MediumType
{
    Card,
    TransponderWithCardInlay,
    Transponder
}