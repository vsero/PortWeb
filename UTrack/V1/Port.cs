namespace UTrack.V1;

public class Port
{
    public Guid Uuid { get; set; }
    public string Title { get; set; } = string.Empty;
    public string LocationCode { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
}
