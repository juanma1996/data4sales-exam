using System.Text.Json.Serialization;

namespace Domain;

public class Response
{
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("next")] public object Next { get; set; }
    [JsonPropertyName("previous")] public object Previous { get; set; }
    [JsonPropertyName("results")] public IEnumerable<Film> Results { get; set; }
}