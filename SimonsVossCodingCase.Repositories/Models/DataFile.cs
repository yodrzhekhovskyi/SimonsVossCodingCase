namespace SimonsVossCodingCase.Repositories.Models;

public class DataFile
{
    public List<Building> Buildings { get; set; } = new List<Building>();
    public List<Lock> Locks { get; set; } = new List<Lock>();
    public List<Group> Groups { get; set; } = new List<Group>();
    public List<Medium> Mediums { get; set; } = new List<Medium>();
}
