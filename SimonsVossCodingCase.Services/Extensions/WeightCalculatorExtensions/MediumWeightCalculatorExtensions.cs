using SimonsVossCodingCase.Services.EntitiesSearchCriterias;
using SimonsVossCodingCase.Services.HelperClasses;
using SimonsVossCodingCase.Services.Helpers;

namespace SimonsVossCodingCase.Services.Extensions.CalculateWeightsExtensions;

public static partial class WeightCalculatorExtensions
{
    public static List<SearchResult> CalculateWeights(this IEnumerable<Medium> mediums, string q)
    {
        if (!string.IsNullOrWhiteSpace(q))
        {
            var searchCriterias = mediums.GetSearchCriterias(q);

            foreach (var searchCriteria in searchCriterias)
            {
                var results = mediums.Where(searchCriteria.Predicate);
                WeightCalculatorHelper.IterateResults(results, searchCriteria, q);
            }
        }

        return PrintHelper.PrintResults(mediums);
    }
}
