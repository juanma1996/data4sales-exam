using Newtonsoft.Json;

namespace Domain
{
    public class People : BaseClass
    {
        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("films")]
        public IEnumerable<Film> Films { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }
        [JsonProperty("species")]
        public IEnumerable<Specie> Species { get; set; }

        [JsonProperty("starships")]
        public IEnumerable<Starship> Starships { get; set; }

        [JsonProperty("vehicles")]
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
