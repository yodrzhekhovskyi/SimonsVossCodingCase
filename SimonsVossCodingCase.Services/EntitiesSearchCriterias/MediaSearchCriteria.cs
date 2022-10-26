using SimonsVossCodingCase.Services.Extensions;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.EntitiesSearchCriterias;

public static partial class SearchCriterias
{
    public static List<SearchCriteria<Medium>> GetSearchCriterias(this IEnumerable<Medium> media, string q) => new()
    {
        new SearchCriteria<Medium>()
        {
            PropName = "MediumType",
            Predicate = x => x.Type.ToString().RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 3
        },
        new SearchCriteria<Medium>()
        {
            PropName = "Owner",
            Predicate = x => x.Owner.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 10,
            ShouldGoDeeper = true,
            TransitiveWeight = 5
        },
        new SearchCriteria<Medium>()
        {
            PropName = "SerialNumber",
            Predicate = x => x.SerialNumber.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 8,
            ShouldGoDeeper = false
        },
        new SearchCriteria<Medium>()
        {
            PropName = "Description",
            Predicate = x => x.Description is not null && x.Description.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 6,
            ShouldGoDeeper = false
        }
    };
}
