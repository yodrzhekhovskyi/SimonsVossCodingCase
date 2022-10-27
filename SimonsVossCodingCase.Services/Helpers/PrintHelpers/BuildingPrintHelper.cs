using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.Helpers.PrintHelpers;

public static partial class PrintHelper
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
}
