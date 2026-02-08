namespace Vsero.UTrcak.V1;

public enum CargoHandlingEventType
{
    Unloading,
    Loading,
    GateIn,
    GateOut,
    YardIn,
    YardOut
}

public class CargoHandlingEvent
{
    public DateTime Timestamp { get; set; } = DateTime.MinValue;

    public CargoHandlingEventType Type { get; set; }

    public CargoHandlingEventLocation Location { get; set; } = new CargoHandlingEventLocation();

    public decimal Quantity { get; set; } = 0m;
}
