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

        DataFile df = new ();

        if (result is not null)
        {
            df = (DataFile)result;
        }

        return df;
    }
}
