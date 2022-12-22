using System.Text.Json.Serialization;

namespace Domain;

public class Film : BaseClass
{
    [JsonPropertyName("characters")] public IEnumerable<string> Characters { get; set; }
    [JsonPropertyName("director")] public string Director { get; set; }
    [JsonPropertyName("episode_id")] public int EpisodeId { get; set; }
    [JsonPropertyName("opening_crawl")] public string OpeningCrawl { get; set; }
    [JsonPropertyName("planets")] public IEnumerable<string> Planets { get; set; }
    [JsonPropertyName("producer")] public string Producer { get; set; }
    [JsonPropertyName("release_date")] public string ReleaseDate { get; set; }
    [JsonPropertyName("cost_in_credits")] public IEnumerable<string> Species { get; set; }
    [JsonPropertyName("cost_in_credits")] public IEnumerable<string> Starships { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("vehicles")] public IEnumerable<string> Vehicles { get; set; }
}