using System.Runtime.Serialization;

namespace UTrack.V1;

public enum CargoFlow
{
    [EnumMember(Value = "from_sea")]
    FromSea,
    [EnumMember(Value = "from_land")]
    FromLand
}

public class CargoSearchFilter
{
    public string SearchString { get => field; set => field = value.Replace(" ",""); } = string.Empty;
    public CargoFlow CargoFlow { get; set; } = CargoFlow.FromSea;
    public bool IsContainerUnit { get; set; } = true;
    public bool IsEmptyContainerUnit { get; set; } = false;
}
