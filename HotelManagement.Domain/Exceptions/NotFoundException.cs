﻿namespace HotelManagement.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base() { }
    public NotFoundException(string? message) : base(message) { }
}
