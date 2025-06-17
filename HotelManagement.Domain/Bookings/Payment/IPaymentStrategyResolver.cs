namespace HotelManagement.Domain.Bookings.Payment
{
    public interface IPaymentStrategyResolver
    {
        IPaymentManager Resolve(string method);
    }
}
