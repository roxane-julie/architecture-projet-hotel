using HotelManagement.Domain.Bookings.Payment;

namespace HotelManagement.Application.Bookings.Payments;

public interface IPaymentSripeUseCase
{
    /// <summary>
    /// Customer pay by stripe
    /// </summary>
    /// <param name="bookingId"></param>
    /// <param name="payment"></param>
    /// <returns></returns>
    Task<PaymentResult> Handle(Guid bookingId, Payment payment);
}
