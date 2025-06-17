using System.Text.Json.Serialization;

namespace HotelManagement.Domain.Bookings.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoomStateType : short
{
    New,
    Redone,
    ToRedo,
    RAS,
    BigDammage
}
