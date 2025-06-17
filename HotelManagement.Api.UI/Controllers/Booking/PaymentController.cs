using HotelManagement.Application.Bookings.Payments;
using HotelManagement.Domain.Bookings.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Api.UI.Controllers.Booking;

[ApiController]
[Route("api/v1/payment")]
[Authorize(Roles = "Receptionist,Customer")]
public class PaymentController : HotelManagementControllerBase
{
    public PaymentController()
    {

    }

    /// <summary>
    /// pay a booking by stripe
    /// </summary>
    /// <param name="bookingId"></param>
    /// <param name="payment"></param>
    /// <param name="paymentSripeUseCase"></param>
    /// <returns></returns>
    [HttpPatch("{bookingId:Guid}/stripe")]
    public async Task<IActionResult> PaymentByStripe(
        Guid bookingId,
        [FromBody] Payment payment,
        [FromServices] IPaymentSripeUseCase paymentSripeUseCase
        )
    {
        PaymentResult result = await paymentSripeUseCase.Handle(bookingId, payment);
        return Ok();
    }

    /// <summary>
    /// pay booking py paypal
    /// </summary>
    /// <param name="bookingId"></param>
    /// <param name="payment"></param>
    /// <param name="paymentPaypalUseCase"></param>
    /// <returns></returns>
    [HttpPatch("{bookingId:Guid}/paypal")]
    public async Task<IActionResult> PaymentByPaypal(
        Guid bookingId,
        [FromBody] Payment payment,
        [FromServices] IPaymentPaypalUseCase paymentPaypalUseCase
        )
    {
        PaymentResult result = await paymentPaypalUseCase.Handle(bookingId, payment);
        return Ok();
    }
}
