using SimonsVossCodingCase.Services.EntitiesSearchCriterias;
using SimonsVossCodingCase.Services.HelperClasses;
using SimonsVossCodingCase.Services.Helpers;

namespace SimonsVossCodingCase.Services.Extensions.CalculateWeightsExtensions;

public static partial class WeightCalculatorExtensions
{
    public static List<SearchResult> CalculateWeights(this IEnumerable<Lock> locks, string q)
    {
        if (!string.IsNullOrWhiteSpace(q))
        {
            var searchCriterias = locks.GetSearchCriterias(q);

            foreach (var searchCriteria in searchCriterias)
            {
                var results = locks.Where(searchCriteria.Predicate);
                WeightCalculatorHelper.IterateResults(results, searchCriteria, q);
            }
        }

        return PrintHelper.PrintResults(locks);
    }
}
