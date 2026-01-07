namespace UTrack.V1;

public class VesselCall
{
    public Guid Uuid { get; set; }
    public string VoyageNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public DateTime DeclaredTimestamp { get; set; }
    public DateOnly EstimatedArrivalDate  { get; set; }
    
}
