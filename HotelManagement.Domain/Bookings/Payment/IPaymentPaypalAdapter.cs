namespace HotelManagement.Domain.Bookings.Payment;

public interface IPaymentPaypalAdapter
{
    /// <summary>
    /// Call api paypal
    /// </summary>
    /// <param name="payment"></param>
    /// <returns></returns>
    Task<PaymentResult> ProcessPaymentAsync(Payment payment);
}

