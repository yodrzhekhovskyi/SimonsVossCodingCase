using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.EntitiesSearchCriterias;
using SimonsVossCodingCase.Services.HelperClasses;
using SimonsVossCodingCase.Services.Helpers;
using SimonsVossCodingCase.Services.Models;

namespace SimonsVossCodingCase.Services.Extensions;

public static class WeightCalculatorExtensions
{
    private static WeightCalculator WeightCalculator { get; set; } = new WeightCalculator();

    public static List<SearchResult> CalculateWeights(this IEnumerable<Building> buildings, string q)
    {
        var searchCriterias = SearchCriterias.GetSearchCriterias(buildings, q);

        foreach (var searchCriteria in searchCriterias)
        {
            var results = buildings.Where(searchCriteria.Predicate);
            WeightCalculator.IterateResults(results, searchCriteria, q);
        }

        return PrintHelper.PrintResults(buildings);
    }

    public static List<SearchResult> CalculateWeights(this IEnumerable<Lock> locks, string q)
    {
        var searchCriterias = SearchCriterias.GetSearchCriterias(locks, q);

        foreach (var searchCriteria in searchCriterias)
        {
            var results = locks.Where(searchCriteria.Predicate);
            WeightCalculator.IterateResults(results, searchCriteria, q);
        }

        return PrintHelper.PrintResults(locks);
    }

    public static List<SearchResult> CalculateWeights(this IEnumerable<Group> groups, string q)
    {
        var searchCriterias = SearchCriterias.GetSearchCriterias(groups, q);

        foreach (var searchCriteria in searchCriterias)
        {
            var results = groups.Where(searchCriteria.Predicate);
            WeightCalculator.IterateResults(results, searchCriteria, q);
        }

        return PrintHelper.PrintResults(groups);
    }

    public static List<SearchResult> CalculateWeights(this IEnumerable<Medium> mediums, string q)
    {
        var searchCriterias = SearchCriterias.GetSearchCriterias(mediums, q);

        foreach (var searchCriteria in searchCriterias)
        {
            var results = mediums.Where(searchCriteria.Predicate);
            WeightCalculator.IterateResults(results, searchCriteria, q);
        }

        return PrintHelper.PrintResults(mediums);
    }
}
