using HotelManagement.Domain.Bookings.Payment;

namespace HotelManagement.Application.Bookings.Payments;

/// <summary>
/// <inheritdoc cref="IPaymentSripeUseCase"/>
/// </summary>
/// <param name="purchaseManager"></param>
public class PaymentSripeUseCase(
    IPurchaseManager purchaseManager
    ) : IPaymentSripeUseCase
{
    public async Task<PaymentResult> Handle(Guid bookingId, Payment payment)
    {
        return await purchaseManager.Pay(payment, "stripe");
    }
}
