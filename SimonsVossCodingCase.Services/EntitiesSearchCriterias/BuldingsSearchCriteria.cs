using SimonsVossCodingCase.Services.Extensions;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.EntitiesSearchCriterias;

public static partial class SearchCriterias
{
    public static List<SearchCriteria<Building>> GetSearchCriterias(this IEnumerable<Building> buildings, string q) => new()
    {
        new SearchCriteria<Building>()
        {
            PropName = "Name",
            Predicate = x => x.Name.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 9,
            ShouldGoDeeper = true,
            TransitiveWeight = 8
        },
        new SearchCriteria<Building>()
        {
            PropName = "ShortCut",
            Predicate = x => x.ShortCut.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 7,
            ShouldGoDeeper = true,
            TransitiveWeight = 5
        },
        new SearchCriteria<Building>()
        {
            PropName = "Description",
            Predicate = x => x.Description.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 5,
            ShouldGoDeeper = false
        },
    };
}
