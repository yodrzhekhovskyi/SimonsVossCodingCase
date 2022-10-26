using AutoMapper;
using SimonsVossCodingCase.Services.Extensions.CalculateWeightsExtensions;
using SimonsVossCodingCase.Services.HelperClasses;
using SimonsVossCodingCase.Services.Interfaces;

namespace SimonsVossCodingCase.Services.Services;

public class SearchService : ISearchService
{
    private static IDataService _dataService = new DataService();
    private IMapper? _mapper;


    public SearchService(IDataService dataService, IMapper mapper) {
        _dataService = dataService;
        _mapper = mapper;
    }

    public List<SearchResult> GetResults(string q)
    {
        var resultsList = new List<SearchResult>();

        if (_mapper is not null)
        {
            var test = _dataService.GetDataFile();
            var results = _mapper.Map<DataFile>(test);

            resultsList.AddRange(results.Buildings.CalculateWeights(q));
            resultsList.AddRange(results.Locks.CalculateWeights(q));
            resultsList.AddRange(results.Groups.CalculateWeights(q));
            resultsList.AddRange(results.Media.CalculateWeights(q));
        }

        return resultsList.OrderByDescending(x => x.Weight).ThenBy(z => z.Name).ToList();
    }
}
