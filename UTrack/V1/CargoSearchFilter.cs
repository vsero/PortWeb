namespace UTrack.V1;

public class CargoSearchFilter
{
    public string SearchString { get => field; set => field = value.Replace(" ",""); } = string.Empty;
    public CargoFlow CargoFlow { get; set; } = CargoFlow.FromSea;
    public bool IsContainerUnit { get; set; } = true;
    public bool IsEmptyContainerUnit { get; set; } = false;
}
