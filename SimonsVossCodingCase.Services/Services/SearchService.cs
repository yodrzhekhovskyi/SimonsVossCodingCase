using SimonsVossCodingCase.Services.Interfaces;

namespace SimonsVossCodingCase.Services.Services;

public class SearchService : ISearchService
{
    public SearchService() { }

    public List<string> GetResults(string q)
    {
        return new List<string>() { "1", "2", "3" };
    }
}
