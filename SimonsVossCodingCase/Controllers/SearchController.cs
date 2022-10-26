using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimonsVossCodingCase.DTOs;
using SimonsVossCodingCase.Services.Interfaces;

namespace SimonsVossCodingCase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;
    private readonly IMapper _mapper;

    public SearchController(ISearchService searchService, IMapper mapper)
    {
        _searchService = searchService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{q?}")]
    public IEnumerable<SearchResultDTO> GetResult(string? q)
        => _mapper.Map<IEnumerable<SearchResultDTO>>(_searchService.GetResults(q ?? string.Empty));
}
