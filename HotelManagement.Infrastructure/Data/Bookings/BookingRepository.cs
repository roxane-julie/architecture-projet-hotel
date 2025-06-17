using HotelManagement.Domain.Bookings;

namespace HotelManagement.Infrastructure.Data.Bookings;

public class BookingRepository : Context<Booking>, IBookingRepository
{
    private readonly string path = "./../HotelManagement.Domain/Bookings/bookings.json";

    public async Task<Booking> Create(Booking booking)
    {
        booking.Id = Guid.NewGuid();
        booking.CreatedOn = DateTime.Now;
        await AddData(path, booking);
        return booking;
    }

    public async Task<Booking?> GetAsync(Guid id)
    {
        var bookings = await GetDataJsonFile(path);
        return bookings.Where(b => b.Id == id).FirstOrDefault();
    }

    public async Task<List<Guid>> GetUnAvailableRoomsIdsForDate(DateTime from, DateTime to)
    {
        var bookings = await GetDataJsonFile(path);
        return bookings
                .Where(b => b.To >= from && b.From <= to)
                .Where(b => !b.IsCancel)
                .Select(b => b.RoomId)
                .ToList();

    }

    public async Task<Booking> Update(Booking booking)
    {
        await UpdateData(path, booking);
        return booking;
    }
}
