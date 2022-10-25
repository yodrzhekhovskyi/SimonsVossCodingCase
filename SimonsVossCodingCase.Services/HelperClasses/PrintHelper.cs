using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.Models;

namespace SimonsVossCodingCase.Services.HelperClasses;

public static class PrintHelper
{
    public static List<SearchResult> PrintResults(IEnumerable<Building> building)
    {
        return building.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            ShortCut = x.ShortCut,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }

    public static List<SearchResult> PrintResults(IEnumerable<Lock> locks)
    {
        return locks.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            LockType = x.LockType.ToString(),
            Floor = x.Floor,
            SerialNumber = x.SerialNumber,
            RoomNumber = x.RoomNumber,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }

    public static List<SearchResult> PrintResults(IEnumerable<Group> groups)
    {
        return groups.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }

    public static List<SearchResult> PrintResults(IEnumerable<Medium> media)
    {
        return media.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Owner,
            Description = x.Description,
            Weight = x.Weight,
            MediumType = x.MediumType.ToString(),
            SerialNumber = x.SerialNumber,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }
}
