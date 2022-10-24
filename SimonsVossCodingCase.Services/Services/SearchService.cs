using SimonsVossCodingCase.Repositories;
using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.Interfaces;
using SimonsVossCodingCase.Services.Models;
using System.Linq;

namespace SimonsVossCodingCase.Services.Services;

public class SearchService : ISearchService
{
    private static DataFile Repository { get; set; } = new DataFile();
    private int FullMatchMultiplier { get; set; } = 10;

    private StringComparison _stringComparison { get; } = StringComparison.InvariantCultureIgnoreCase;

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
         
        resultsList.AddRange(CalculateBuildindsWeights(results.Buildings, q));
        resultsList.AddRange(CalculateLocksWeights(results.Locks, q));
        resultsList.AddRange(CalculateGroupsWeights(results.Groups, q));
        resultsList.AddRange(CalculateMediumsWeights(results.Media, q));

        return resultsList.OrderByDescending(x => x.Weight).ThenBy(z => z.Name).ToList();
    }

    private class PredicateClass<T>
    {
        public string PropName { get; set; } = string.Empty;
        public Func<T, bool> Predicate { get; set; }

        public int Weight { get; set; } = 0;
        public bool ShouldGoDeeper { get; set; } = false;

        public int TransitiveWeight { get; set; } = 0;
    }


    public List<SearchResult> CalculateBuildindsWeights(IEnumerable<Building> buildings, string q)
    {
        List<PredicateClass<Building>> predicatesList = new()
        {
            new PredicateClass<Building>()
            {
                PropName = "Name",
                Predicate = x => x.Name.Contains(q, _stringComparison),
                Weight = 9,
                ShouldGoDeeper = true,
                TransitiveWeight = 8
            },
            new PredicateClass<Building>()
            {
                PropName = "ShortCut",
                Predicate = x => x.ShortCut.Contains(q, _stringComparison),
                Weight = 7,
                ShouldGoDeeper = true,
                TransitiveWeight = 5
            },
            new PredicateClass<Building>()
            {
                PropName = "Description",
                Predicate = x => x.Description.Contains(q, _stringComparison),
                Weight = 5,
                ShouldGoDeeper = false
            },
        };

        foreach (var predicate in predicatesList)
        {
            var results = buildings.Where(predicate.Predicate);

            foreach (var result in results)
            {
                var value = result.GetType()?.GetProperty(predicate.PropName)?.GetValue(result, null)?.ToString();

                if (value is not null)
                {
                    if (value.Equals(q, _stringComparison))
                    {
                        result.Weight += predicate.Weight * FullMatchMultiplier;
                    }
                    else
                    {
                        result.Weight += predicate.Weight;
                    }

                    if (predicate.ShouldGoDeeper)
                    {
                        foreach (var @lock in result.Locks)
                        {
                            @lock.Weight += predicate.TransitiveWeight;
                        }
                    }
                }
            }
        }

        return buildings.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }

    public List<SearchResult> CalculateLocksWeights(IEnumerable<Lock> locks, string q)
    {
        List<PredicateClass<Lock>> predicatesList = new()
        {
            new PredicateClass<Lock>()
            {
                PropName = "LockType",
                Predicate = x => x.LockType.ToString().Contains(q, _stringComparison),
                Weight = 3
            },
            new PredicateClass<Lock>()
            {
                PropName = "Name",
                Predicate = x => x.Name.Contains(q, _stringComparison),
                Weight = 10,
                ShouldGoDeeper = true,
                TransitiveWeight = 5
            },
            new PredicateClass<Lock>()
            {
                PropName = "SerialNumber",
                Predicate = x => x.SerialNumber.Contains(q, _stringComparison),
                Weight = 8,
                ShouldGoDeeper = false
            },
            new PredicateClass<Lock>()
            {
                PropName = "Floor",
                Predicate = x => x.Floor is not null && x.Floor.Contains(q, _stringComparison),
                Weight = 6,
                ShouldGoDeeper = false
            },
            new PredicateClass<Lock>()
            {
                PropName = "RoomNumber",
                Predicate = x => x.Floor is not null && x.Floor.Contains(q, _stringComparison),
                Weight = 6,
                ShouldGoDeeper = false
            },
            new PredicateClass<Lock>()
            {
                PropName = "Description",
                Predicate = x => x.Floor is not null && x.Floor.Contains(q, _stringComparison),
                Weight = 6,
                ShouldGoDeeper = false
            },
        };

        foreach (var predicate in predicatesList)
        {
            var results = locks.Where(predicate.Predicate);

            foreach (var result in results)
            {
                var value = result.GetType()?.GetProperty(predicate.PropName)?.GetValue(result, null)?.ToString();

                if (value is not null)
                {
                    if (value.Equals(q, _stringComparison))
                    {
                        result.Weight += predicate.Weight * FullMatchMultiplier;
                    }
                    else
                    {
                        result.Weight += predicate.Weight;
                    }
                }
            }
        }

        return locks.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }

    public List<SearchResult> CalculateGroupsWeights(IEnumerable<Group> groups, string q)
    {
        List<PredicateClass<Group>> predicatesList = new()
        {
            new PredicateClass<Group>()
            {
                PropName = "Name",
                Predicate = x => x.Name.Contains(q, _stringComparison),
                Weight = 9,
                ShouldGoDeeper = true,
                TransitiveWeight = 8
            },
            new PredicateClass<Group>()
            {
                PropName = "Description",
                Predicate = x => x.Description is not null && x.Description.Contains(q, _stringComparison),
                Weight = 5
            }
        };

        foreach (var predicate in predicatesList)
        {
            var results = groups.Where(predicate.Predicate);

            foreach (var result in results)
            {
                var value = result.GetType()?.GetProperty(predicate.PropName)?.GetValue(result, null)?.ToString();

                if (value is not null)
                {
                    if (value.Equals(q, _stringComparison))
                    {
                        result.Weight += predicate.Weight * FullMatchMultiplier;
                    }
                    else
                    {
                        result.Weight += predicate.Weight;
                    }

                    if (predicate.ShouldGoDeeper)
                    {
                        foreach (var medium in result.Media)
                        {
                            medium.Weight += predicate.TransitiveWeight;
                        }
                    }
                }
            }
        }

        return groups.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }

    public List<SearchResult> CalculateMediumsWeights(IEnumerable<Medium> media, string q)
    {
        List<PredicateClass<Medium>> predicatesList = new()
        {
            new PredicateClass<Medium>()
            {
                PropName = "MediumType",
                Predicate = x => x.MediumType.ToString().Contains(q, _stringComparison),
                Weight = 3
            },
            new PredicateClass<Medium>()
            {
                PropName = "Owner",
                Predicate = x => x.Owner.Contains(q, _stringComparison),
                Weight = 10,
                ShouldGoDeeper = true,
                TransitiveWeight = 5
            },
            new PredicateClass<Medium>()
            {
                PropName = "SerialNumber",
                Predicate = x => x.SerialNumber.Contains(q, _stringComparison),
                Weight = 8,
                ShouldGoDeeper = false
            },
            new PredicateClass<Medium>()
            {
                PropName = "Description",
                Predicate = x => x.Description is not null && x.Description.Contains(q, _stringComparison),
                Weight = 6,
                ShouldGoDeeper = false
            }
        };

        foreach (var predicate in predicatesList)
        {
            var results = media.Where(predicate.Predicate);

            foreach (var result in results)
            {
                var value = result.GetType()?.GetProperty(predicate.PropName)?.GetValue(result, null)?.ToString();

                if (value is not null)
                {
                    if (value.Equals(q, _stringComparison))
                    {
                        result.Weight += predicate.Weight * FullMatchMultiplier;
                    }
                    else
                    {
                        result.Weight += predicate.Weight;
                    }
                }
            }
        }

        return media.Select(x => new SearchResult
        {
            Id = x.Id,
            Name = x.Owner,
            Description = x.Description,
            Weight = x.Weight,
            Type = x.GetType().Name.ToString()
        }).ToList();
    }
}
