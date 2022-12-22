using System.Text.Json.Serialization;

namespace Domain;

public class People : BaseClass
{
    [JsonPropertyName("birth_year")] public string BirthYear { get; set; }

    [JsonPropertyName("eye_color")] public string EyeColor { get; set; }

    [JsonPropertyName("gender")] public string Gender { get; set; }

    [JsonPropertyName("hair_color")] public string HairColor { get; set; }

    [JsonPropertyName("height")] public string Height { get; set; }

    //[JsonIgnore]
    //public Planet Homeworld { get; set; }

    [JsonPropertyName("mass")] public string Mass { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("skin_color")] public string SkinColor { get; set; }

    public string Homeworld { get; set; }
    public List<string> Species { get; set; }
    public List<string> Starships { get; set; }
    public List<string> Vehicles { get; set; }
    public List<string> Films { get; set; }
}