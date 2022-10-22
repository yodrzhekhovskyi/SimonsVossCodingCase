using SimonsVossCodingCase.Repositories;
using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.Interfaces;

namespace SimonsVossCodingCase.Services.Services;

public class SearchService : ISearchService
{
    private static DataFile? Repository { get; set; }

    public SearchService() {
        Repository = FakeDbGenerator.GetDataFile();
    }

    public List<string> GetResults(string q)
    {
        var test = Repository;

        return new List<string>() { "1", "2", "3" };
    }
}
