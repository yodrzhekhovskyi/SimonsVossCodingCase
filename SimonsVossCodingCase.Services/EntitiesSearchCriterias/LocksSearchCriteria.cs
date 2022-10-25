using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.EntitiesSearchCriterias
{
    public static partial class SearchCriterias
    {
        public static List<SearchCriteria<Lock>> GetSearchCriterias(this IEnumerable<Lock> locks, string q) => new()
        {
            new SearchCriteria<Lock>()
            {
                PropName = "LockType",
                Predicate = x => x.LockType.ToString().Contains(q, StringComparison),
                Weight = 3
            },
            new SearchCriteria<Lock>()
            {
                PropName = "Name",
                Predicate = x => x.Name.Contains(q, StringComparison),
                Weight = 10,
                ShouldGoDeeper = true,
                TransitiveWeight = 5
            },
            new SearchCriteria<Lock>()
            {
                PropName = "SerialNumber",
                Predicate = x => x.SerialNumber.Contains(q, StringComparison),
                Weight = 8,
                ShouldGoDeeper = false
            },
            new SearchCriteria<Lock>()
            {
                PropName = "Floor",
                Predicate = x => x.Floor is not null && x.Floor.Contains(q, StringComparison),
                Weight = 6,
                ShouldGoDeeper = false
            },
            new SearchCriteria<Lock>()
            {
                PropName = "RoomNumber",
                Predicate = x => x.Floor is not null && x.Floor.Contains(q, StringComparison),
                Weight = 6,
                ShouldGoDeeper = false
            },
            new SearchCriteria<Lock>()
            {
                PropName = "Description",
                Predicate = x => x.Floor is not null && x.Floor.Contains(q, StringComparison),
                Weight = 6,
                ShouldGoDeeper = false
            },
        };
    }
}
