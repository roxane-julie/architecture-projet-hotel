namespace HotelManagement.Application.Bookings;

public interface ICustomerLeaved
{
    /// <summary>
    /// Check if customer has payed booking and mark room need clean and confirm customer have leave
    /// </summary>
    /// <param name="bookingId"></param>
    /// <returns></returns>
    Task Handle(Guid bookingId);
}
