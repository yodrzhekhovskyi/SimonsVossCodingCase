using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.EntitiesSearchCriterias;

public static partial class SearchCriterias
{
    public static List<SearchCriteria<Medium>> GetSearchCriterias(this IEnumerable<Medium> media, string q) => new()
    {
        new SearchCriteria<Medium>()
        {
            PropName = "MediumType",
            Predicate = x => x.MediumType.ToString().Contains(q, StringComparison),
            Weight = 3
        },
        new SearchCriteria<Medium>()
        {
            PropName = "Owner",
            Predicate = x => x.Owner.Contains(q, StringComparison),
            Weight = 10,
            ShouldGoDeeper = true,
            TransitiveWeight = 5
        },
        new SearchCriteria<Medium>()
        {
            PropName = "SerialNumber",
            Predicate = x => x.SerialNumber.Contains(q, StringComparison),
            Weight = 8,
            ShouldGoDeeper = false
        },
        new SearchCriteria<Medium>()
        {
            PropName = "Description",
            Predicate = x => x.Description is not null && x.Description.Contains(q, StringComparison),
            Weight = 6,
            ShouldGoDeeper = false
        }
    };
}
