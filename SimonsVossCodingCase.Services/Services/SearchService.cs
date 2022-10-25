using SimonsVossCodingCase.Repositories;
using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.Extensions;
using SimonsVossCodingCase.Services.Interfaces;
using SimonsVossCodingCase.Services.Models;

namespace SimonsVossCodingCase.Services.Services;

public class SearchService : ISearchService
{
    private static DataFile Repository { get; set; } = new DataFile();
    
    public SearchService() {
        Repository = FakeDbGenerator.GetDataFile();
    }

    public List<SearchResult> GetResults(string q)
    {
        var results = Repository;

        var resultsList = new List<SearchResult>();
        if (string.IsNullOrWhiteSpace(q))
        {
            return resultsList;
        }
         
        resultsList.AddRange(results.Buildings.CalculateWeights(q));
        resultsList.AddRange(results.Locks.CalculateWeights(q));
        resultsList.AddRange(results.Groups.CalculateWeights(q));
        resultsList.AddRange(results.Media.CalculateWeights(q));

        return resultsList.OrderByDescending(x => x.Weight).ThenBy(z => z.Name).ToList();
    }
}
