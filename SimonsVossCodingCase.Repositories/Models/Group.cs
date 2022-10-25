namespace SimonsVossCodingCase.Repositories.Models;

public class Group : BaseEntity
{
    public Group()
    {
        Type = GetType().Name.ToString();
    }

    public IEnumerable<Medium> Media { get; set; } = Enumerable.Empty<Medium>();
}
