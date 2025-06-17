namespace HotelManagement.Application.Bookings;

public interface ICancelBooking
{
    /// <summary>
    /// Cancel a booking and refund
    /// </summary>
    /// <param name="bookingId"></param>
    /// <param name="refund"></param>
    /// <returns></returns>
    Task<string> Handle(Guid bookingId, bool refund);
}
