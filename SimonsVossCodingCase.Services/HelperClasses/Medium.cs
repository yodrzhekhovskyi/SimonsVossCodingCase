namespace SimonsVossCodingCase.Services.HelperClasses;

public class Medium : BaseEntity
{
    public Medium()
    {
        Name = Owner;
        EntityType = GetType().Name.ToString();
    }
    public Guid GroupId { get; set; }
    public MediumType Type { get; set; }
    public string Owner { get; set; } = string.Empty;

    public string SerialNumber { get; set; } = string.Empty;
}

public enum MediumType
{
    Card,
    TransponderWithCardInlay,
    Transponder
}
