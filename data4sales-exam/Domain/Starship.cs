using Newtonsoft.Json;

namespace Domain
{
    public class Starship : Vehicle
    {
        [JsonProperty("MGLT")]
        public string Mglt { get; set; }

        [JsonProperty("hyperdrive_rating")]
        public string HyperdriveRating { get; set; }

        [JsonProperty("starship_class")]
        public string StarshipClass { get; set; }
    }

}
