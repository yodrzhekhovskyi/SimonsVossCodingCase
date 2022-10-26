using AutoMapper;
using SimonsVossCodingCase.Services.HelperClasses;

namespace SimonsVossCodingCase.Services.Profiles;

public class ServiceAutoMapperProfile : Profile
{
    public ServiceAutoMapperProfile()
    {
        CreateMap<Repositories.Models.Building, Building>();
        CreateMap<Repositories.Models.Group, Group>();
        CreateMap<Repositories.Models.Lock, Lock>();
        CreateMap<Repositories.Models.Medium, Medium>();
        CreateMap<Repositories.Models.DataFile, DataFile>().AfterMap((src, dest) => {
            foreach (var building in dest.Buildings)
            {
                building.Locks = dest.Locks.Where(x => x.BuildingId == building.Id);
            }

            foreach (var group in dest.Groups)
            {
                group.Media = dest.Media.Where(x => x.GroupId == group.Id);
            }
        });
    }
}
