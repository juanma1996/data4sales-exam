using Newtonsoft.Json;

namespace Domain
{
    public class BaseClass
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("edited")]
        public DateTime Edited { get; set; }
    }
}
