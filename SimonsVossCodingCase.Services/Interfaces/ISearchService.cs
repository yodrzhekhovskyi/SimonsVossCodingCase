using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.Interfaces;

public interface ISearchService
{
    public List<SearchResult> GetResults(string q);
}
