using HotelManagement.Domain.Bookings;
using HotelManagement.Domain.Exceptions;

namespace HotelManagement.Application.Bookings;


/// <inheritdoc cref="ICustomerLeaved"/>
public class CustomerLeaved(
        IBookingRepository bookingRepository,
        IRoomRepository roomRepository
    ) : ICustomerLeaved
{
    public async Task Handle(Guid bookingId)
    {
        Booking booking = await bookingRepository.GetAsync(bookingId)
           ?? throw new NotFoundException("booking doest't exist");
        Room room = await roomRepository.GetAsync(booking.RoomId)
            ?? throw new NotFoundException("room doest exist");

        if (!booking.Payed)
            throw new BadRequestException("The booking must be paid before");

        booking.HasLeave = true;
        _ = await bookingRepository.Update(booking);
        room.IsCleaned = false;
        _ = await roomRepository.UpdateRoom(room);
    }
}
