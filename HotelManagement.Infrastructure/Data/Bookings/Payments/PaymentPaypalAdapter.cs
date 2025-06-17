using HotelManagement.Domain.Bookings.Payment;

namespace HotelManagement.Infrastructure.Data.Bookings.Payments;

/// <summary>
/// <inheritdoc cref="IPaymentPaypalAdapter"/>
/// </summary>
public class PaymentPaypalAdapter : IPaymentPaypalAdapter
{
    public Task<PaymentResult> ProcessPaymentAsync(Payment payment)
    {
        Console.WriteLine("Processing payment with Paypal calling Paypal API");
        return Task.FromResult(PaymentResult.SuccessResult());
    }
}