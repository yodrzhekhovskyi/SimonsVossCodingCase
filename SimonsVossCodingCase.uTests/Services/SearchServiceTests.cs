using AutoMapper;
using FluentAssertions;
using Moq;
using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.Interfaces;
using SimonsVossCodingCase.Services.Profiles;
using SimonsVossCodingCase.Services.Services;

namespace SimonsVossCodingCase.uTests.Services;

public class SearchServiceTests
{
    [Fact]
    public void CheckBuildingsAndLocks()
    {
        //Setup
        var building = GetBuildingMock();
        var buildingId = building.Id;
        var locks = GetLocksMock(buildingId);
        var firstLockId = locks.ElementAt(0).Id;
        var secondLockId = locks.ElementAt(1).Id;

        var dataFile = new DataFile()
        {
            Buildings = new List<Building>() { building },
            Locks = locks
        };

        var service = new SearchService( GetDataServiceMock(dataFile), GetAutoMapper());

        //Act
        var result = service.GetResults("Head Office");

        //Assert
        result.First().Id.Should().Be(buildingId);
        result[1].Id.Should().Be(secondLockId);
        result[2].Id.Should().Be(firstLockId);
    }

    [Fact]
    public void CheckGroupsAndMedia()
    {
        //Setup
        var group = GetGroupMock();
        var groupId = group.Id;
        var media = GetMedia(groupId);
        var firstMediumId = media.ElementAt(0).Id;
        var secondMediumId = media.ElementAt(1).Id;

        var dataFile = new DataFile()
        {
            Groups = new List<Group>() { group },
            Media = media
        };

        var service = new SearchService(GetDataServiceMock(dataFile), GetAutoMapper());

        //Act
        var result = service.GetResults("medium 2");

        //Assert
        result.First().Id.Should().Be(secondMediumId);
        result[1].Id.Should().Be(groupId);
        result[2].Id.Should().Be(firstMediumId);
    }

    [Fact]
    public void CheckBuildingsLocksGroupsAndMedia()
    {
        //Setup
        var building = GetBuildingMock();
        var buildingId = building.Id;

        var locks = GetLocksMock(buildingId);
        var firstLockId = locks.ElementAt(0).Id;
        var secondLockId = locks.ElementAt(1).Id;

        var group = GetGroupMock();
        var groupId = group.Id;

        var media = GetMedia(groupId);
        var firstMediumId = media.ElementAt(0).Id;
        var secondMediumId = media.ElementAt(1).Id;

        var dataFile = new DataFile()
        {
            Buildings = new List<Building>() { building },
            Locks = locks,
            Groups = new List<Group>() { group },
            Media = media
        };

        var service = new SearchService(GetDataServiceMock(dataFile), GetAutoMapper());

        //Act
        var result = service.GetResults("head");

        //Assert
        result[0].Id.Should().Be(firstMediumId);
        result[1].Id.Should().Be(secondMediumId);
        result[2].Id.Should().Be(firstLockId);
        result[3].Id.Should().Be(secondLockId);
        result[4].Id.Should().Be(buildingId);
        result[5].Id.Should().Be(groupId);
    }

    private static IDataService GetDataServiceMock(DataFile dataFile)
    {
        var dataServiceMock = new Mock<IDataService>();
        dataServiceMock.Setup(x => x.GetDataFile()).Returns(dataFile);

        return dataServiceMock.Object;
    }

    private static Building GetBuildingMock()
    {
        Building building = new()
        {
            Id = Guid.NewGuid(),
            Description = "Head Office on the some street",
            Name = "Head Office",
            ShortCut = string.Empty
        };

        return building;
    }

    private static List<Lock> GetLocksMock(Guid buildingId) 
        => new ()
        {
            new Lock()
            {
                Id = Guid.NewGuid(),
                BuildingId = buildingId,
                Description = "Head"
            },
            new Lock()
            {
                Id = Guid.NewGuid(),
                BuildingId = buildingId,
                Description = "Head office"
            }
        };

    private static Group GetGroupMock()
    {
        Group group = new()
        {
            Id = Guid.NewGuid(),
            Name = "Some head group with medium 2",
            Description = "Nice group",
        };

        return group;
    }

    private static List<Medium> GetMedia(Guid groupId)
        => new()
        {
            new Medium()
            {
                Id = new Guid(),
                Name = "medium 1",
                Owner = "mr head",
                SerialNumber = "SN/123/medium1",
                GroupId = groupId,
                Description = "Some nice medium"
            },
            new Medium()
            {
                Id = new Guid(),
                Name = "medium 2",
                Owner = "mr head",
                SerialNumber = "SN/123/medium2",
                GroupId = groupId,
                Description = "Another nice medium"
            }
        };

    private static IMapper GetAutoMapper()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new ServiceAutoMapperProfile()));
        IMapper mapper = new Mapper(configuration);

        return mapper;
    }
}
