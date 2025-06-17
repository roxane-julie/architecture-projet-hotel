using HotelManagement.Domain.Bookings.Payment;

namespace HotelManagement.Infrastructure.Data.Bookings.Payments;

/// <summary>
/// payment stripe manager on pattern strategie payment
/// </summary>
/// <param name="paymentStripeAdapter"></param>
public class StripePaymentManager(IPaymentStripeAdapter paymentStripeAdapter) : IPaymentManager
{
    public string Method => "stripe";

    public async Task<PaymentResult> Pay(Payment payment)
    {
        return await paymentStripeAdapter.ProcessPaymentAsync(payment);
    }
}