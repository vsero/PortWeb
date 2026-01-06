using System.Text.Json.Serialization;

namespace UTrack.V1
{
    public class Vessel
    {
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; } = Guid.NewGuid();
        
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("callsign")]
        public string Callsign { get; set; } = string.Empty;
    }
}