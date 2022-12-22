using System.Text.Json.Serialization;

namespace Domain;

public class Planet : BaseClass
{
    [JsonPropertyName("climate")] public string Climate { get; set; }

    [JsonPropertyName("diameter")] public string Diameter { get; set; }

    [JsonPropertyName("gravity")] public string Gravity { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("orbital_period")] public string OrbitalPeriod { get; set; }

    [JsonPropertyName("population")] public string Population { get; set; }

    public List<string> Residents { get; set; }

    //[JsonIgnore]
    //public List<People> Residents { get; set; }

    [JsonPropertyName("rotation_period")] public string RotationPeriod { get; set; }

    [JsonPropertyName("surface_water")] public string SurfaceWater { get; set; }

    [JsonPropertyName("terrain")] public string Terrain { get; set; }
}