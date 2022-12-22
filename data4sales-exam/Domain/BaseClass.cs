using System.Text.Json.Serialization;

namespace Domain;

public class BaseClass
{
    public int Id { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("created")] public DateTime Created { get; set; }

    [JsonPropertyName("edited")] public DateTime Edited { get; set; }
}