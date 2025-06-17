using HotelManagement.Domain.Bookings;

namespace HotelManagement.Infrastructure.Data.Bookings;

/// <summary>
/// <inheritdoc cref="IRoomRepository"/>
/// </summary>
public class RoomRepository : Context<Room>, IRoomRepository
{
    private readonly string path = "./../HotelManagement.Domain/Bookings/rooms.json";
    public async Task<Room?> GetAsync(Guid id)
    {
        List<Room> rooms = await GetDataJsonFile(path);
        return rooms.Where(r => r.Id == id).FirstOrDefault();
    }

    public async Task<List<Room>> GetRoomsByUnAvailableIds(List<Guid> roomsIds)
    {
        List<Room> rooms = await GetDataJsonFile(path);
        return rooms.Where(r => !roomsIds.Contains(r.Id)).ToList();
    }
    public async Task<List<Room>> GetRoomsToClean()
    {
        List<Room> rooms = await GetDataJsonFile(path);
        return rooms.Where(r => !r.IsCleaned).ToList();
    }

    public async Task<Room> UpdateRoom(Room room)
    {
        await UpdateData(path, room);
        return room;
    }
}
