using System.Text.Json.Serialization;

namespace UTrack.V1;

public class CargoHandlingEventLocation
{
    public Vehicle? Vehicle { get; set; }
    public Vessel? Vessel { get; set; }
    public Yard? Yard { get; set; }
    public Gate? Gate { get; set; }


    [JsonIgnore]
    public string Title => this switch
    {
        { Vehicle: not null } => Vehicle.Title,
        { Vessel: not null } => Vessel.Title,
        { Yard: not null } => Yard.Title,
        { Gate: not null } => Gate.Title,
        _ => "<Unknown location type>"
    };

}
