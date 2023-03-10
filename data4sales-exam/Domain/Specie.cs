using System.Text.Json.Serialization;

namespace Domain;

public class Specie : BaseClass
{
    [JsonPropertyName("average_height")] public string AverageHeight { get; set; }
    [JsonPropertyName("average_lifespan")] public string AverageLifespan { get; set; }
    [JsonPropertyName("classification")] public string Classification { get; set; }
    [JsonPropertyName("designation")] public string Designation { get; set; }
    [JsonPropertyName("eye_colors")] public string EyeColors { get; set; }
    [JsonPropertyName("hair_colors")] public string HairColors { get; set; }
    [JsonPropertyName("language")] public string Language { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("skin_colors")] public string SkinColors { get; set; }
    [JsonPropertyName("homeworld")] public string Homeworld { get; set; }
    [JsonPropertyName("people")] public IEnumerable<string> People { get; set; }
}