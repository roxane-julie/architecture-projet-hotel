using HotelManagement.Domain.Bookings.Payment;

namespace HotelManagement.Application.Bookings.Payments;

/// <summary>
/// <inheritdoc cref="IPaymentPaypalUseCase"/>
/// </summary>
/// <param name="purchaseManager"></param>
public class PaymentPaypalUseCase(
        IPurchaseManager purchaseManager
    ) : IPaymentPaypalUseCase
{
    public async Task<PaymentResult> Handle(Guid bookingId, Payment payment)
    {
        return await purchaseManager.Pay(payment, "paypal");
    }
}
