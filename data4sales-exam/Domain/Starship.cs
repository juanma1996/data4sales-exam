using System.Text.Json.Serialization;

namespace Domain;

public class Starship : Vehicle
{
    [JsonPropertyName("MGLT")] public string Mglt { get; set; }

    [JsonPropertyName("hyperdrive_rating")] public string HyperdriveRating { get; set; }

    [JsonPropertyName("starship_class")] public string StarshipClass { get; set; }
}