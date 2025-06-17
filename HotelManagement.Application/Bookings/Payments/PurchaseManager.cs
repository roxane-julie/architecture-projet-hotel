using HotelManagement.Domain.Bookings.Payment;

namespace HotelManagement.Application.Bookings.Payments;

/// <summary>
/// <inheritdoc cref="IPurchaseManager"/>
/// </summary>
/// <param name="paymentStrategyResolver"></param>
public class PurchaseManager(IPaymentStrategyResolver paymentStrategyResolver) : IPurchaseManager
{
    public async Task<PaymentResult> Pay(Payment payment, string method)
    {
        var strategy = paymentStrategyResolver.Resolve(method);
        return await strategy.Pay(payment);
    }
}

/// <summary>
/// Manage purchase
/// </summary>
public interface IPurchaseManager
{
    Task<PaymentResult> Pay(Payment payment, string method);
}
