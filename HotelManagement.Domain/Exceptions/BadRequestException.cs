﻿namespace HotelManagement.Domain.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException() : base() { }
    public BadRequestException(string? message) : base(message) { }
}
