using System.Text.Json.Serialization;

namespace Domain;

public class Vehicle : BaseClass
{
    [JsonPropertyName("cargo_capacity")] public string CargoCapacity { get; set; }

    [JsonPropertyName("consumables")] public string Consumables { get; set; }

    [JsonPropertyName("cost_in_credits")] public string CostInCredits { get; set; }

    [JsonPropertyName("crew")] public string Crew { get; set; }

    [JsonPropertyName("length")] public string Length { get; set; }

    [JsonPropertyName("manufacturer")] public string Manufacturer { get; set; }

    [JsonPropertyName("max_atmosphering_speed")]
    public string MaxAtmospheringSpeed { get; set; }

    [JsonPropertyName("model")] public string Model { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("passengers")] public string Passengers { get; set; }

    [JsonPropertyName("vehicle_class")] public string VehicleClass { get; set; }

    public List<string> Pilots { get; set; }
}