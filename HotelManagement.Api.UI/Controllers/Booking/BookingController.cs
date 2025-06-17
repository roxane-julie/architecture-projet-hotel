using HotelManagement.Application.Authentication;
using HotelManagement.Application.Bookings;
using HotelManagement.Application.Bookings.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Api.UI.Controllers.Booking;

[ApiController]
[Route("api/v1/booking")]
[Authorize(Roles = "Receptionist,Customer")]
public class BookingController : HotelManagementControllerBase
{
    public BookingController()
    {

    }


    /// <summary>
    /// creake a booking on a specific room
    /// </summary>
    /// <param name="roomid"></param>
    /// <returns></returns>
    [HttpPost("{roomid:Guid}")]
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> Booking(
        Guid roomid,
        [FromBody] BookingDto bookingDto,
        [FromServices] ICreateBooking createBooking,
        [FromServices] ICurrentUserTokenAdapter currentUserTokenAdapter
        )
    {
        bookingDto.CustomerId = currentUserTokenAdapter.GetUserId();

        return Ok(await createBooking.Handle(bookingDto));
    }

    /// <summary>
    /// end pint for cancel booking
    /// </summary>
    /// <param name="bookindId"></param>
    /// <param name="refund"></param>
    /// <param name="cancelBooking"></param>
    /// <param name="currentUserTokenAdapter"></param>
    /// <returns></returns>
    [Authorize(Roles = "Customer,Receptionist")]
    [HttpPatch("{id:Guid}/cancel")]
    [HttpPatch("{id:Guid}/cancel/{refund:bool}")]
    public async Task<IActionResult> CancelBooking(
            Guid bookindId,
            bool refund,
            ICancelBooking cancelBooking,
            ICurrentUserTokenAdapter currentUserTokenAdapter
        )
    {
        string message = await cancelBooking.Handle(bookindId, refund);
        return Ok(message);
    }

    /// <summary>
    /// Manage arrived customer
    /// </summary>
    /// <param name="bookindId"></param>
    /// <param name="customerArrived"></param>
    /// <returns></returns>
    [Authorize(Roles = "Receptionist")]
    [HttpPatch("{id:Guid}/arrived")]
    public async Task<IActionResult> Arrived(
        Guid bookindId,
        [FromServices] ICustomerArrived customerArrived
    )
    {
        await customerArrived.Handle(bookindId);
        return Ok();
    }

    /// <summary>
    /// mangage leaver customer
    /// </summary>
    /// <param name="bookindId"></param>
    /// <param name="customerLeaved"></param>
    /// <returns></returns>
    [Authorize(Roles = "Receptionist")]
    [HttpPatch("{id:Guid}/leave")]
    public async Task<IActionResult> Leave(
        Guid bookindId,
        [FromServices] ICustomerLeaved customerLeaved
    )
    {
        await customerLeaved.Handle(bookindId);
        return Ok();
    }

}
