using System.Text.Json.Serialization;

namespace UTrack.V1
{
    public class Vehicle
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
    }
}