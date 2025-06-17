namespace HotelManagement.Domain.Bookings.Payment;

public interface IPaymentManager
{
    string Method { get; } // Ex: "stripe", "paypal"
    Task<PaymentResult> Pay(Payment payment);
}
