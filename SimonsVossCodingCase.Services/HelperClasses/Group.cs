namespace SimonsVossCodingCase.Services.HelperClasses;

public class Group : BaseEntity
{
    public Group()
    {
        EntityType = GetType().Name.ToString();
    }

    public IEnumerable<Medium> Media { get; set; } = Enumerable.Empty<Medium>();
}
