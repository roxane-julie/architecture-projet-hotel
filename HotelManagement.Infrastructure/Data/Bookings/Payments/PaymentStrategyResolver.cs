using HotelManagement.Domain.Bookings.Payment;
using HotelManagement.Domain.Exceptions;

namespace HotelManagement.Infrastructure.Data.Bookings.Payments;

/// <summary>
/// Resolve payment strategie for a stragegy pattern
/// </summary>
public class PaymentStrategyResolver : IPaymentStrategyResolver
{
    private readonly Dictionary<string, IPaymentManager> _strategies;

    public PaymentStrategyResolver(IEnumerable<IPaymentManager> strategies)
    {
        _strategies = strategies.ToDictionary(s => s.Method, StringComparer.OrdinalIgnoreCase);
    }

    public IPaymentManager Resolve(string method)
    {
        if (_strategies.TryGetValue(method, out var strategy))
            return strategy;

        throw new BadRequestException($"Payment method '{method}' is not supported.");
    }
}
