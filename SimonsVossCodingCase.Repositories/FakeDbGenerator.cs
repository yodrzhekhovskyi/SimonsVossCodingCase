using Newtonsoft.Json;
using SimonsVossCodingCase.Repositories.Models;

namespace SimonsVossCodingCase.Repositories;

public class FakeDbGenerator
{
    public static DataFile GetDataFile()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sv_lsm_data.json");
        var json = File.ReadAllText(path);

        var result = JsonConvert.DeserializeObject(json, typeof(DataFile));

        DataFile dt = new ();

        if (result is not null)
        {
            dt = (DataFile)result;

            foreach (var building in dt.Buildings)
            {
                building.Locks = dt.Locks.Where(x => x.BuildingId == building.Id);
            }

            foreach (var group in dt.Groups)
            {
                group.Media = dt.Media.Where(x => x.GroupId == group.Id);
            }

        }

        return dt;
    }
}
