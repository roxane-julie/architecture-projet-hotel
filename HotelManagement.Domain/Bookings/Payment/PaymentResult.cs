namespace HotelManagement.Domain.Bookings.Payment;
public class PaymentResult
{
    public string TransactionId { get; set; }
    public PaymentResultStatusType Status { get; set; }

    public static PaymentResult SuccessResult()
    {
        return new PaymentResult
        {
            TransactionId = Guid.NewGuid().ToString(),
            Status = PaymentResultStatusType.Success
        };
    }
}


public enum PaymentResultStatusType
{
    Success,
    Failure
}

