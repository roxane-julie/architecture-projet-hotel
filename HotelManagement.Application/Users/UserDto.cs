using HotelManagement.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HotelManagement.Application.Users;

public record UserDto
{
    public Guid Id { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
    public string EmailAddress { get; init; } = "";

    public string HashedPassword { get; init; } = "";
    public string FirstName { get; init; } = "";
    public string LastName { get; init; } = "";

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RoleType Role { get; init; }
}
