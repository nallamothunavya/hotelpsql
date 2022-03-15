using System.Text.Json.Serialization;
using Hotelsql.Models;

namespace Hotelsql.DTOs;

public record StaffDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name{ get; set; }

    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("gender")]
    public Gender  Gender{ get; set; }

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("shift")]
    public StaffShift Shift { get; set; }

    [JsonPropertyName("rooms")]

    public RoomDTO Rooms {get; set;}
}


public record StaffCreatedto
{



    [JsonPropertyName("name")]
    public string Name{ get; set; }

    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("gender")]
    public Gender  Gender{ get; set; }

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("shift")]
    public StaffShift Shift { get; set; }
}



public record StaffUpdatedto
{

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("shift")]
    public StaffShift Shift { get; set; }

}