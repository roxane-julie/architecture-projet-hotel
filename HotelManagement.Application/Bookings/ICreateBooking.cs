using HotelManagement.Application.Bookings.Dtos;

namespace HotelManagement.Application.Bookings;

public interface ICreateBooking
{
    /// <summary>
    /// Create a booking
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BookingDto> Handle(BookingDto dto);
}
