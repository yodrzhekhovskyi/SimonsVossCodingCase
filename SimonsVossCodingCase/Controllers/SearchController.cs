using Microsoft.AspNetCore.Mvc;
using SimonsVossCodingCase.Services.Interfaces;

namespace SimonsVossCodingCase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    [Route("{q?}")]
    public IEnumerable<string> GetResult(string? q)
    {
        var results = _searchService.GetResults(q ?? string.Empty);

        return results;
    }
}
