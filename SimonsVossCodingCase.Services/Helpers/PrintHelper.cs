using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.Helpers;

public static class PrintHelper
{
    public static List<SearchResult> PrintResults(IEnumerable<Building> building)
        => building.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            ShortCut = x.ShortCut,
            EntityType = x.EntityType
        }).ToList();

    public static List<SearchResult> PrintResults(IEnumerable<Lock> locks)
        => locks.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.Type.ToString(),
            Floor = x.Floor,
            SerialNumber = x.SerialNumber,
            RoomNumber = x.RoomNumber,
            EntityType = x.EntityType
        }).ToList();

    public static List<SearchResult> PrintResults(IEnumerable<Group> groups)
        => groups.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            EntityType = x.EntityType
        }).ToList();

    public static List<SearchResult> PrintResults(IEnumerable<Medium> media)
        => media.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Owner,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.Type.ToString(),
            SerialNumber = x.SerialNumber,
            EntityType = x.EntityType
        }).ToList();
}
