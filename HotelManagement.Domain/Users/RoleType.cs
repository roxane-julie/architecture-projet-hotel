using System.Text.Json.Serialization;

namespace HotelManagement.Domain.Users
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleType
    {
        Customer,
        Receptionist,
        CleaningStaff
    }
}