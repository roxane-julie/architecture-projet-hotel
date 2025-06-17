namespace HotelManagement.Domain.Bookings.Payment;


public interface IPaymentStripeAdapter
{
    /// <summary>
    /// call api stripe
    /// </summary>
    /// <param name="payment"></param>
    /// <returns></returns>
    Task<PaymentResult> ProcessPaymentAsync(Payment payment);
}
