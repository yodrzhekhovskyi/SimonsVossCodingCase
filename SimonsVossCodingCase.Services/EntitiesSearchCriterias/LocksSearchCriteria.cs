using SimonsVossCodingCase.Services.Extensions;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.EntitiesSearchCriterias;

public static partial class SearchCriterias
{
    public static List<SearchCriteria<Lock>> GetSearchCriterias(this IEnumerable<Lock> locks, string q) => new()
    {
        new SearchCriteria<Lock>()
        {
            PropName = "LockType",
            Predicate = x => x.Type.ToString().RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 3
        },
        new SearchCriteria<Lock>()
        {
            PropName = "Name",
            Predicate = x => x.Name.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 10,
            ShouldGoDeeper = true,
            TransitiveWeight = 5
        },
        new SearchCriteria<Lock>()
        {
            PropName = "SerialNumber",
            Predicate = x => x.SerialNumber.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 8,
            ShouldGoDeeper = false
        },
        new SearchCriteria<Lock>()
        {
            PropName = "Floor",
            Predicate = x => x.Floor is not null && x.Floor.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 6,
            ShouldGoDeeper = false
        },
        new SearchCriteria<Lock>()
        {
            PropName = "RoomNumber",
            Predicate = x => x.RoomNumber is not null && x.RoomNumber.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 6,
            ShouldGoDeeper = false
        },
        new SearchCriteria<Lock>()
        {
            PropName = "Description",
            Predicate = x => x.Description is not null && x.Description.RemoveWhiteSpaces().Contains(q.RemoveWhiteSpaces(), Constants.ContainsStringComparition),
            Weight = 6,
            ShouldGoDeeper = false
        },
    };
}
