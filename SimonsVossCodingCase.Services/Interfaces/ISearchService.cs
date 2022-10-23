using SimonsVossCodingCase.Services.Models;

namespace SimonsVossCodingCase.Services.Interfaces;

public interface ISearchService
{
    public List<SearchResult> GetResults(string q);
}
