using System.Text.Json.Serialization;

namespace UTrack.V1;

public enum HandlingEventType
{
    [JsonStringEnumMemberName("unloading")]
    Unloading,
    [JsonStringEnumMemberName("loading")]
    Loading,
    [JsonStringEnumMemberName("gate_in")]
    GateIn,
    [JsonStringEnumMemberName("gate_out")]
    GateOut,
    [JsonStringEnumMemberName("yard_in")]
    YardIn,
    [JsonStringEnumMemberName("yard_out")]
    YardOut
}

public class HandlingEvent
{
    [JsonPropertyName("event_timestamp")]
    public DateTime Timestamp { get; set; } = DateTime.MinValue;

    [JsonPropertyName("cargo_handling_event_type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public HandlingEventType HandlingEventType { get; set; }

    [JsonPropertyName("cargo_handlind_event_location")]
    public HandlingEventLocation Location { get; set; } = new HandlingEventLocation();

    [JsonPropertyName("allocated_quantity")]
    public decimal AllocatedQuantity { get; set; } = 0m;


    [JsonIgnore]
    public string HandlingEventTypeRu => HandlingEventType switch
    {
        HandlingEventType.Unloading => "Выгрузка",
        HandlingEventType.Loading => "Погрузка",
        HandlingEventType.GateIn => "Заезд на территорию",
        HandlingEventType.GateOut => "Выезд с территории",
        HandlingEventType.YardIn => "Помещен на хранение",
        HandlingEventType.YardOut => "Снят с хранения",
        _ => "<Неизвестное событие>"
    };

}
