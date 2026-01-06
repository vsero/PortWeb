namespace UTrack.V1;

public enum CargoFlow
{
    Inbound,
    Outbound
}

public class SearchFilter
{
    public string SearchString { get; set; } = "DLTU9018145";
    public CargoFlow CargoFlow { get; set; } = CargoFlow.Inbound;
    public bool IsContainerUnit { get; set; } = true;
    public bool IsEmptyContainerUnit { get; set; } = false;
}
