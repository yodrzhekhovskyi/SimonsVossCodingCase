using SimonsVossCodingCase.Repositories;
using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.Interfaces;
using SimonsVossCodingCase.Services.Models;

namespace SimonsVossCodingCase.Services.Services;

public class SearchService : ISearchService
{
    private static DataFile Repository { get; set; }
    private int FullMatchMultiplier { get; set; } = 10;


    public SearchService() {
        Repository = FakeDbGenerator.GetDataFile();
    }

    public List<SearchResult> GetResults(string q)
    {
        var results = Repository;

        var resultsList = new List<SearchResult>();
        if (string.IsNullOrWhiteSpace(q))
        {
            return resultsList;
        }
         
        resultsList.AddRange(CalculateBuildindsWeights(results, q));
        resultsList.AddRange(CalculateLocksWeights(results, q));
        resultsList.AddRange(CalculateGroupsWeights(results, q));
        resultsList.AddRange(CalculateMediumsWeights(results, q));

        return resultsList.OrderByDescending(x => x.Weight).ThenBy(z => z.Name).ToList();
    }

    public List<SearchResult> CalculateBuildindsWeights(DataFile dataFile, string q)
    {
        var partialMatchNameBuildings = dataFile.Buildings.Where(x => x.Name.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var building in partialMatchNameBuildings)
        {
            if (building.Name.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                building.Weight += 9 * FullMatchMultiplier;
            }
            else
            {
                building.Weight += 9;
            }
            
            foreach (var @lock in building.Locks)
            {
                @lock.Weight += 8;
            }
        }

        var fullMatchShortcutBuildings = dataFile.Buildings.Where(x => x.ShortCut.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var building in fullMatchShortcutBuildings)
        {
            if (building.ShortCut.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                building.Weight += 7 * FullMatchMultiplier;
            }
            else
            {
                building.Weight += 7;
            }
                
            foreach (var @lock in building.Locks)
            {
                @lock.Weight += 5;
            }
        }

        var fullMatchDescriptionBuildings = dataFile.Buildings.Where(x => x.Description.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var building in fullMatchDescriptionBuildings)
        {
            if (building.Description.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                building.Weight += 5 * FullMatchMultiplier;
            }
            else
            {
                building.Weight += 5;
            }
        }


        return dataFile.Buildings.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }

    public List<SearchResult> CalculateLocksWeights(DataFile dataFile, string q)
    {
        // TODO for type
        var fullMatchLockTypeLocks = dataFile.Locks.Where(x => x.LockType.ToString().Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var building in fullMatchLockTypeLocks)
        {
            if (building.LockType.ToString().Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                building.Weight += 3 * FullMatchMultiplier;
            }
            else
            {
                building.Weight += 3;
            }
        }

        var fullMatchNameLocks = dataFile.Locks.Where(x => x.Name.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var @lock in fullMatchNameLocks)
        {
            if (@lock.Name.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                @lock.Weight += 10 * FullMatchMultiplier;
            }
            else
            {
                @lock.Weight += 10;
            }
        }

        var fullMatchSerialNumberLocks = dataFile.Locks.Where(x => x.SerialNumber.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var @lock in fullMatchSerialNumberLocks)
        {
            if (@lock.SerialNumber.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                @lock.Weight += 8 * FullMatchMultiplier;
            }
            else
            {
                @lock.Weight += 8;
            }
        }

        var fullMatchShortcutLocks = dataFile.Locks.Where(x => x.Floor is not null && x.Floor.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var @lock in fullMatchShortcutLocks)
        {
            if (@lock.Floor.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                @lock.Weight += 6 * FullMatchMultiplier;
            }
            else
            {
                @lock.Weight += 6;
            }
        }

        var fullMatchRoomNumberLocks = dataFile.Locks.Where(x => x.RoomNumber is not null && x.RoomNumber.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var @lock in fullMatchRoomNumberLocks)
        {
            if (@lock.RoomNumber.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                @lock.Weight += 6 * FullMatchMultiplier;
            }
            else
            {
                @lock.Weight += 6;
            }
        }

        var fullMatchDescriptionLocks = dataFile.Locks.Where(x => x.Description is not null && x.Description.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var @lock in fullMatchDescriptionLocks)
        {
            if (@lock.Description.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                @lock.Weight += 6 * FullMatchMultiplier;
            }
            else
            {
                @lock.Weight += 6;
            }
        }

        return dataFile.Locks.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }

    public List<SearchResult> CalculateGroupsWeights(DataFile dataFile, string q)
    {
        var fullMatchNameGroups = dataFile.Groups.Where(x => x.Name.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var group in fullMatchNameGroups)
        {
            if (group.Name.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                group.Weight += 9 * FullMatchMultiplier;
            }
            else
            {
                group.Weight += 9;
            }
            
            foreach (var medium in group.Mediums)
            {
                medium.Weight += 8;
            }
        }

        var fullMatchDescriptionGroups = dataFile.Groups.Where(x => x.Description is not null && x.Description.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var group in fullMatchDescriptionGroups)
        {
            if (group.Description.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                group.Weight += 5 * FullMatchMultiplier;
            }
            else
            {
                group.Weight += 5;
            }
        }

        return dataFile.Groups.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }

    public List<SearchResult> CalculateMediumsWeights(DataFile dataFile, string q)
    {
        // TODO for type
        var fullMatchLockTypeMediums = dataFile.Mediums.Where(x => x.MediumType.ToString().Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var medium in fullMatchLockTypeMediums)
        {
            if (medium.Description.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                medium.Weight += 3 * FullMatchMultiplier;
            }
            else
            {
                medium.Weight += 3;
            }
        }

        var fullMatchOwnerMediums = dataFile.Mediums.Where(x => x.Owner.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var medium in fullMatchOwnerMediums)
        {
            if (medium.Owner.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                medium.Weight += 10 * FullMatchMultiplier;
            }
            else
            {
                medium.Weight += 10;
            }
        }

        var fullMatchSerialNumberMediums = dataFile.Mediums.Where(x => x.SerialNumber.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var medium in fullMatchSerialNumberMediums)
        {
            if (medium.SerialNumber.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                medium.Weight += 8 * FullMatchMultiplier;
            }
            else
            {
                medium.Weight += 8;
            }
        }

        var fullMatchDescriptionMediums = dataFile.Mediums.Where(x => x.Description is not null && x.Description.Equals(q, StringComparison.InvariantCultureIgnoreCase));
        foreach (var medium in fullMatchDescriptionMediums)
        {
            if (medium.Description.Equals(q, StringComparison.InvariantCultureIgnoreCase))
            {
                medium.Weight += 6 * FullMatchMultiplier;
            }
            else
            {
                medium.Weight += 6;
            }
        }

        return dataFile.Mediums.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Owner,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }
}
