using Newtonsoft.Json;

namespace Domain;

public class Planet : BaseClass
{
    [JsonProperty("climate")] public string Climate { get; set; }

    [JsonProperty("diameter")] public string Diameter { get; set; }

    [JsonProperty("gravity")] public string Gravity { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("orbital_period")] public string OrbitalPeriod { get; set; }

    [JsonProperty("population")] public string Population { get; set; }

    public List<string> Residents { get; set; }

    //[JsonIgnore]
    //public List<People> Residents { get; set; }

    [JsonProperty("rotation_period")] public string RotationPeriod { get; set; }

    [JsonProperty("surface_water")] public string SurfaceWater { get; set; }

    [JsonProperty("terrain")] public string Terrain { get; set; }
}