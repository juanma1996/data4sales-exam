﻿using Newtonsoft.Json;

namespace Domain
{
    public class Specie : BaseClass
    {
        [JsonProperty("average_height")]
        public string AverageHeight { get; set; }

        [JsonProperty("average_lifespan")]
        public string AverageLifespan { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("eye_colors")]
        public string EyeColors { get; set; }

        [JsonProperty("hair_colors")]
        public string HairColors { get; set; }

        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("people")]
        public List<People> People { get; set; }

        [JsonProperty("films")]
        public List<Film> Films { get; set; }

        [JsonProperty("skin_colors")]
        public string SkinColors { get; set; }
    }
}