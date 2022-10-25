namespace SimonsVossCodingCase.Repositories.Models;

public class Building : BaseEntity
{
    public Building()
    {
        Type = GetType().Name.ToString();
    }

    public IEnumerable<Lock> Locks { get; set; } = Enumerable.Empty<Lock>();
    public string ShortCut { get; set; } = string.Empty;
}
