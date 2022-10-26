namespace SimonsVossCodingCase.Services.HelperClasses;

public class Lock : BaseEntity
{
    public Lock()
    {
        EntityType = GetType().Name.ToString();
    }
    public Guid BuildingId { get; set; }
    public LockType Type { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string Floor { get; set; } = string.Empty;
    public string RoomNumber { get; set; } = string.Empty;
    public enum LockType
    {
        Cylinder,
        SmartHandle
    }
}

