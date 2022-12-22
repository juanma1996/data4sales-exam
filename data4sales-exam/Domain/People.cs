using Newtonsoft.Json;

namespace Domain;

public class People : BaseClass
{
    [JsonProperty("birth_year")] public string BirthYear { get; set; }

    [JsonProperty("eye_color")] public string EyeColor { get; set; }

    [JsonProperty("gender")] public string Gender { get; set; }

    [JsonProperty("hair_color")] public string HairColor { get; set; }

    [JsonProperty("height")] public string Height { get; set; }

    //[JsonIgnore]
    //public Planet Homeworld { get; set; }

    [JsonProperty("mass")] public string Mass { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("skin_color")] public string SkinColor { get; set; }

    public string Homeworld { get; set; }
    public List<string> Species { get; set; }
    public List<string> Starships { get; set; }
    public List<string> Vehicles { get; set; }
    public List<string> Films { get; set; }
}