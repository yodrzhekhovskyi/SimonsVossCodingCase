namespace SimonsVossCodingCase.Repositories.Models;

public class Building
{
    public Guid Id { get; set; }
    public IEnumerable<Lock> Locks { get; set; } = Enumerable.Empty<Lock>();
    public string ShortCut { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int Weight { get; set; } = 0;
}
