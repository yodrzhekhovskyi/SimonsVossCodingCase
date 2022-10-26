using SimonsVossCodingCase.Repositories;
using SimonsVossCodingCase.Repositories.Models;
using SimonsVossCodingCase.Services.Interfaces;

namespace SimonsVossCodingCase.Services.Services;

public class DataService : IDataService
{
    private static readonly DataFile Repository = FakeDbGenerator.GetDataFile();

    public DataFile GetDataFile() => Repository;
}
