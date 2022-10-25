namespace SimonsVossCodingCase.Repositories.Models;

public class Lock : BaseEntity
{
    public Lock()
    {
        Type = GetType().Name.ToString();
    }
    public Guid BuildingId { get; set; }
    public LockType LockType { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string Floor { get; set; } = string.Empty;
    public string RoomNumber { get; set; } = string.Empty;
}

public enum LockType
{
    Cylinder,
    SmartHandle
}
