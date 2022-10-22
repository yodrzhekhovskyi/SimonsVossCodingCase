namespace SimonsVossCodingCase.Repositories.Models;

public class Group
{
    public Guid Id { get; set; }
    public IEnumerable<Medium> Mediums { get; set; } = Enumerable.Empty<Medium>();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
