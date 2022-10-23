namespace SimonsVossCodingCase.Services.Models;

public class SearchResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Weight { get; set; } = 0;
    public string Type { get; set; } = string.Empty;
}
