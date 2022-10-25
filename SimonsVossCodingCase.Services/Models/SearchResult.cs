using SimonsVossCodingCase.Repositories.Models;

namespace SimonsVossCodingCase.Services.Models;

public class SearchResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Weight { get; set; } = 0;
    public string Type { get; set; } = string.Empty;
    public string ShortCut { get; set; } = string.Empty;
    public string LockType { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string Floor { get; set; } = string.Empty;
    public string RoomNumber { get; set; } = string.Empty;
    public string MediumType { get; set; }
}
