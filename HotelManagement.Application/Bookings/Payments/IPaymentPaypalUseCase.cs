using HotelManagement.Domain.Bookings.Payment;

namespace HotelManagement.Application.Bookings.Payments;

public interface IPaymentPaypalUseCase
{
    /// <summary>
    /// Customer pay by paypal
    /// </summary>
    /// <param name="bookingId"></param>
    /// <param name="payment"></param>
    /// <returns></returns>
    Task<PaymentResult> Handle(Guid bookingId, Payment payment);
}
