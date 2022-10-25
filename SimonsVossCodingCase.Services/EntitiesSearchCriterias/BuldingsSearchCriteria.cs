using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.EntitiesSearchCriterias
{
    public static partial class SearchCriterias
    {
        private static StringComparison StringComparison { get; } = StringComparison.InvariantCultureIgnoreCase;

        public static List<SearchCriteria<Building>> GetSearchCriterias(this IEnumerable<Building> buildings, string q) => new()
        {
            new SearchCriteria<Building>()
            {
                PropName = "Name",
                Predicate = x => x.Name.Contains(q, StringComparison),
                Weight = 9,
                ShouldGoDeeper = true,
                TransitiveWeight = 8
            },
            new SearchCriteria<Building>()
            {
                PropName = "ShortCut",
                Predicate = x => x.ShortCut.Contains(q, StringComparison),
                Weight = 7,
                ShouldGoDeeper = true,
                TransitiveWeight = 5
            },
            new SearchCriteria<Building>()
            {
                PropName = "Description",
                Predicate = x => x.Description.Contains(q, StringComparison),
                Weight = 5,
                ShouldGoDeeper = false
            },
        };
    }
}
