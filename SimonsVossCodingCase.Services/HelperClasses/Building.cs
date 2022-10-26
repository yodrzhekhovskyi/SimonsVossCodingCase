namespace SimonsVossCodingCase.Services.HelperClasses;

public class Building : BaseEntity
{
    public Building()
    {
        EntityType = GetType().Name.ToString();
    }

    public IEnumerable<Lock> Locks { get; set; } = Enumerable.Empty<Lock>();
    public string ShortCut { get; set; } = string.Empty;
}
