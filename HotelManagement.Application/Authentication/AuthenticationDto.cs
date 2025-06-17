using System.ComponentModel;

namespace HotelManagement.Application.Authentication;

public class AuthenticationDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

[Description("Auth response model")]
public class AuthenticationResponseDto
{
    [Description("JWT token")]
    public required string Token { get; set; }
}
