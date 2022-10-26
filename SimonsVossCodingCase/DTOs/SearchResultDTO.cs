namespace SimonsVossCodingCase.DTOs;

public class SearchResultDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Weight { get; set; } = 0;
    public string ShortCut { get; set; } = string.Empty;
    public string? Type { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string Floor { get; set; } = string.Empty;
    public string RoomNumber { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
}
