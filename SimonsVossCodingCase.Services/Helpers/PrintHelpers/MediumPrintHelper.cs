using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.Helpers.PrintHelpers;

public static partial class PrintHelper
{
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
