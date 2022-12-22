using Newtonsoft.Json;

namespace Domain;

public class Film : BaseClass
{
    public List<string> Characters { get; set; }

    //public IEnumerable<People> Characters { get; set; }

    [JsonProperty("director")] public string Director { get; set; }

    [JsonProperty("episode_id")] public int EpisodeId { get; set; }

    [JsonProperty("opening_crawl")] public string OpeningCrawl { get; set; }

    public List<string> Planets { get; set; }

    //[JsonProperty("planets")]
    //public IEnumerable<Planet> Planets { get; set; }

    [JsonProperty("producer")] public string Producer { get; set; }

    [JsonProperty("release_date")] public string ReleaseDate { get; set; }

    //[JsonProperty("species")]
    //public IEnumerable<Specie> Species { get; set; }

    //[JsonProperty("starships")]
    //public IEnumerable<Starship> Starships { get; set; }

    public List<string> Species { get; set; }
    public List<string> Starships { get; set; }

    [JsonProperty("title")] public string Title { get; set; }

    //[JsonProperty("vehicles")]
    //public IEnumerable<Vehicle> Vehicles { get; set; }

    public List<string> Vehicles { get; set; }
}