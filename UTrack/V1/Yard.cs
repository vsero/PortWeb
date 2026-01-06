using System.Text.Json.Serialization;

namespace UTrack.V1
{
    public class Yard
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("terminal_title")]
        public string TerminalTitle { get; set; } = string.Empty;
    }
}