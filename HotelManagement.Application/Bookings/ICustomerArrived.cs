namespace HotelManagement.Application.Bookings;

public interface ICustomerArrived
{
    /// <summary>
    /// confirms customer arrival 
    /// </summary>
    /// <param name="bookingId"></param>
    /// <returns></returns>
    Task Handle(Guid bookingId);
}
