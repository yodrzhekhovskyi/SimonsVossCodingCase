using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.Helpers.PrintHelpers;

public static partial class PrintHelper
{
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
}
