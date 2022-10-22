namespace SimonsVossCodingCase.Repositories.Models;

public class Lock
{
    public Guid Id { get; set; }
    public Guid BuildingId { get; set; }
    public LockType LockType { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string Floor { get; set; } = string.Empty;
    public string RoomNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public enum LockType
{
    Cylinder,
    SmartHandle
}
