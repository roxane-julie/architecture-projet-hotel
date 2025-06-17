using System.Text.Json.Serialization;

namespace HotelManagement.Domain.Bookings.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoomType
{
    simpleType = 1,
    doubleType = 2,
    suiteType = 3
}
