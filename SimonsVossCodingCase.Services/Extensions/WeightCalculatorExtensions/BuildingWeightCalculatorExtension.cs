using SimonsVossCodingCase.Services.EntitiesSearchCriterias;
using SimonsVossCodingCase.Services.HelperClasses;
using SimonsVossCodingCase.Services.Helpers;

namespace SimonsVossCodingCase.Services.Extensions.CalculateWeightsExtensions;

public static partial class WeightCalculatorExtensions
{
    private static WeightCalculatorHelper WeightCalculator { get; set; } = new WeightCalculatorHelper();

    public static List<SearchResult> CalculateWeights(this IEnumerable<Building> buildings, string q)
    {
        if (!string.IsNullOrWhiteSpace(q))
        {
            var searchCriterias = buildings.GetSearchCriterias(q);

            foreach (var searchCriteria in searchCriterias)
            {
                var results = buildings.Where(searchCriteria.Predicate);
                WeightCalculatorHelper.IterateResults(results, searchCriteria, q);
            }
        }

        return PrintHelper.PrintResults(buildings);
    }
}
