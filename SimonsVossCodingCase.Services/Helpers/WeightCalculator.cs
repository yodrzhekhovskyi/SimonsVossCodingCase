using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.Helpers;

internal class WeightCalculator
{
    private StringComparison StringComparison { get; } = StringComparison.InvariantCultureIgnoreCase;
    private static int FullMatchMultiplier { get; set; } = 10;

    public void IterateResults<T>(IEnumerable<T> results, SearchCriteria<T> predicate, string q) where T : BaseEntity
    {
        foreach (var result in results)
        {
            var value = result.GetType()?.GetProperty(predicate.PropName)?.GetValue(result, null)?.ToString();

            if (value is not null)
            {
                bool shouldMultiplyForFullMatch = false;

                if (value.Equals(q, StringComparison))
                {
                    result.Weight += predicate.Weight * FullMatchMultiplier;
                    shouldMultiplyForFullMatch = true;
                }
                else
                {
                    result.Weight += predicate.Weight;
                }

                if (predicate.ShouldGoDeeper)
                {
                    IterateNestedList(result, predicate, shouldMultiplyForFullMatch);
                }
            }
        }
    }

    public static void IterateNestedList<T>(T result, SearchCriteria<T> predicate, bool shouldMultiplyForFullMatch)
    {
        if (result is Building)
        {
            var castedList = (result as Building)?.Locks;

            if (castedList is not null)
            {
                foreach (var @lock in castedList)
                {
                    if (shouldMultiplyForFullMatch)
                    {
                        @lock.Weight += predicate.TransitiveWeight * FullMatchMultiplier;
                    }
                    else
                    {
                        @lock.Weight += predicate.TransitiveWeight;
                    }
                }
            }
        }

        if (result is Group)
        {
            var castedList = (result as Group)?.Media;

            if (castedList is not null)
            {
                foreach (var group in castedList)
                {
                    if (shouldMultiplyForFullMatch)
                    {
                        group.Weight += predicate.TransitiveWeight * FullMatchMultiplier;
                    }
                    else
                    {
                        group.Weight += predicate.TransitiveWeight;
                    }
                }
            }
        }
    }
}
