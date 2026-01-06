using System.Text.Json.Serialization;

namespace UTrack.V1;

public class ShipmentTrack
{
    [JsonPropertyName("uuid")]
    public Guid Uuid { get; set; } = Guid.NewGuid();

    [JsonPropertyName("declared_timestamp")]
    public DateTime DeclaredTimestamp { get; set; } = DateTime.MinValue;

    [JsonPropertyName("label")]
    public string Label { get; set; } = string.Empty;
    
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("bl_number")]
    public string BlNumber { get; set; } = string.Empty;

    [JsonPropertyName("cargo_handling_events")]
    public IEnumerable<HandlingEvent> HandlingEvents { get; set; } = [];
}
