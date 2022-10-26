using AutoMapper;
using SimonsVossCodingCase.DTOs;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SearchResult, SearchResultDTO>();
    }
}
