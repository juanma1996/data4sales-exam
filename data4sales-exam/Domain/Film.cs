using System.Text.Json.Serialization;

namespace Domain;

public class Film : BaseClass
{
    public List<string> Characters { get; set; }

    //public IEnumerable<People> Characters { get; set; }

    [JsonPropertyName("director")] public string Director { get; set; }

    [JsonPropertyName("episode_id")] public int EpisodeId { get; set; }

    [JsonPropertyName("opening_crawl")] public string OpeningCrawl { get; set; }

    public List<string> Planets { get; set; }

    //[JsonPropertyName("planets")]
    //public IEnumerable<Planet> Planets { get; set; }

    [JsonPropertyName("producer")] public string Producer { get; set; }

    [JsonPropertyName("release_date")] public string ReleaseDate { get; set; }

    //[JsonPropertyName("species")]
    //public IEnumerable<Specie> Species { get; set; }

    //[JsonPropertyName("starships")]
    //public IEnumerable<Starship> Starships { get; set; }

    public List<string> Species { get; set; }
    public List<string> Starships { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    //[JsonPropertyName("vehicles")]
    //public IEnumerable<Vehicle> Vehicles { get; set; }

    public List<string> Vehicles { get; set; }
}