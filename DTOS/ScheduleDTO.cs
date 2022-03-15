using System.Text.Json.Serialization;

namespace Hotelsql.DTOs;

public record ScheduleDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("check_in")]
    public DateTimeOffset CheckIn { get; set; }

    [JsonPropertyName("check_out")]
    public DateTimeOffset CheckOut { get; set; }

    [JsonPropertyName("guest_count")]
    public int GuestCount { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("room")]
    public RoomDTO Rooms { get; set; }

    [JsonPropertyName("guest")]

    public GuestDTO Guests {get;set;}


}


public record ScheduleCreatedto
{


    [JsonPropertyName("check_in")]
    public DateTimeOffset CheckIn { get; set; }

    [JsonPropertyName("check_out")]
    public DateTimeOffset CheckOut { get; set; }

    [JsonPropertyName("guest_count")]
    public int GuestCount { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("created_at")]

    public DateTimeOffset CreatedAt{get;set;}

    [JsonPropertyName("guest_id")]

    public int GuestId{get;set;}

    [JsonPropertyName("rooom_id")]

    public int RoomId{get;set;}
}

public record ScheduleUpdatedto
{
    [JsonPropertyName("check_in")]
    public DateTimeOffset CheckIn { get; set; }

    [JsonPropertyName("check_out")]
    public DateTimeOffset CheckOut { get; set; }

    [JsonPropertyName("guest_count")]
    public int GuestCount { get; set; }

}