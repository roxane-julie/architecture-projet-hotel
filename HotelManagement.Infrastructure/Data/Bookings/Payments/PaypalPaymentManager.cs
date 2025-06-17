using HotelManagement.Domain.Bookings.Payment;

namespace HotelManagement.Infrastructure.Data.Bookings.Payments;

/// <summary>
/// payment paypal manager on pattern strategie payment
/// </summary>
/// <param name="paymentPaypalAdapter"></param>
public class PaypalPaymentManager(IPaymentPaypalAdapter paymentPaypalAdapter) : IPaymentManager
{
    public string Method => "paypal";

    public async Task<PaymentResult> Pay(Payment payment)
    {
        return await paymentPaypalAdapter.ProcessPaymentAsync(payment);
    }
}