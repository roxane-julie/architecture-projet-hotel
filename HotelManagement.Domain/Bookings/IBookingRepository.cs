namespace HotelManagement.Domain.Bookings;

public interface IBookingRepository : IBaseRepository<Booking>
{
    /// <summary>
    /// get unavailable roomid for date
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    Task<List<Guid>> GetUnAvailableRoomsIdsForDate(DateTime from, DateTime to);

    /// <summary>
    /// Create booking
    /// </summary>
    /// <param name="booking"></param>
    /// <returns></returns>
    Task<Booking> Create(Booking booking);

    /// <summary>
    /// update booking
    /// </summary>
    /// <param name="booking"></param>
    /// <returns></returns>
    Task<Booking> Update(Booking booking);
}
