using HotelManagement.Application.Authentication;
using HotelManagement.Domain.Bookings;
using HotelManagement.Domain.Exceptions;
using HotelManagement.Domain.Users;

namespace HotelManagement.Application.Bookings;

/// <summary>
/// <inheritdoc cref="ICancelBooking"/>
/// </summary>
/// <param name="bookingRepository"></param>
/// <param name="currentUserTokenAdapter"></param>
public class CancelBooking(
        IBookingRepository bookingRepository,
        ICurrentUserTokenAdapter currentUserTokenAdapter
    ) : ICancelBooking
{
    public async Task<string> Handle(Guid bookingId, bool refund = true)
    {
        Booking booking = await bookingRepository.GetAsync(bookingId)
            ?? throw new NotFoundException("booking dosent exist");

        if (booking.CustomerId != currentUserTokenAdapter.GetUserId() || currentUserTokenAdapter.GetUserRole() != nameof(RoleType.Receptionist))
            throw new BadRequestException("error, on cancel booking. Customer not correct or Contact receptionist for cancel booking");

        string message = "Votre annulation a bien été effectuée.";
        booking.IsCancel = true;
        await bookingRepository.Update(booking);

        // If the user is a customer and the booking  is within 2 days from today, we set the refund to false.
        if ((DateTime.Now.AddDays(-2).Date > booking.From.Date
            && currentUserTokenAdapter.GetUserRole() == nameof(RoleType.Customer) || !refund))
        {
            message += "Vous ne serez pas remboursé, car votre demande a été faite moins de 48 heures avant la date de réservation.";
            Console.WriteLine($"Not refund booking : {bookingId}");

        }
        else if (refund)
        {
            message += "Vous allez être remboursé du prix de votre réservation.";
            Console.WriteLine($"Refund booking : {bookingId}");
        }

        return message;
    }
}
