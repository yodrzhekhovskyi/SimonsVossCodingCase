namespace SimonsVossCodingCase.Services.HelperClasses;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Weight { get; set; } = 0;
    public string EntityType { get; set; } = string.Empty;
}
