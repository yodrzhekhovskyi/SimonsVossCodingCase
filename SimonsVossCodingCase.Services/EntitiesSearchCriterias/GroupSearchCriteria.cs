using SimonsVossCodingCase.Services.Extensions;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.EntitiesSearchCriterias;

public static partial class SearchCriterias
{
    public static List<SearchCriteria<Group>> GetSearchCriterias(this IEnumerable<Group> groups, string q) => new()
    {
        new SearchCriteria<Group>()
        {
            PropName = "Name",
            Predicate = x => x.Name.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 9,
            ShouldGoDeeper = true,
            TransitiveWeight = 8
        },
        new SearchCriteria<Group>()
        {
            PropName = "Description",
            Predicate = x => x.Description is not null && x.Description.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 5
        }
    };
}
