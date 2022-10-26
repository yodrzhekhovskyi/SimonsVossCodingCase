namespace SimonsVossCodingCase.Repositories.Models;

public class Building
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ShortCut { get; set; } = string.Empty;
}
