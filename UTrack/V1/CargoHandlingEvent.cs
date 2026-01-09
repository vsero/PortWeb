using System.Text.Json.Serialization;

namespace UTrack.V1;

public enum CargoHandlingEventType
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

public class CargoHandlingEvent
{
    public DateTime Timestamp { get; set; } = DateTime.MinValue;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CargoHandlingEventType Type { get; set; }

    public CargoHandlingEventLocation Location { get; set; } = new CargoHandlingEventLocation();

    public decimal Quantity { get; set; } = 0m;


    [JsonIgnore]
    public string TypeRu => Type switch
    {
        CargoHandlingEventType.Unloading => "Выгрузка",
        CargoHandlingEventType.Loading => "Погрузка",
        CargoHandlingEventType.GateIn => "Ввоз на территорию",
        CargoHandlingEventType.GateOut => "Вывоз с территории",
        CargoHandlingEventType.YardIn => "Помещен на хранение",
        CargoHandlingEventType.YardOut => "Снят с хранения",
        _ => "<Неизвестное событие>"
    };

}
