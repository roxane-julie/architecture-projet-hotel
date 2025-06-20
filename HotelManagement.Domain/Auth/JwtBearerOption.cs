﻿namespace HotelManagement.Domain.Auth;

public class JwtBearerOption
{
    public required string Audience { get; set; }
    public required string Issuer { get; set; }
    public required string Key { get; set; }
}
