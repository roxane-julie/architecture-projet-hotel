namespace HotelManagement.Domain.Bookings;

public interface IRoomRepository : IBaseRepository<Room>
{
    /// <summary>
    /// Get unvailable room by ids
    /// </summary>
    /// <param name="roomsIds"></param>
    /// <returns></returns>
    Task<List<Room>> GetRoomsByUnAvailableIds(List<Guid> roomsIds);

    /// <summary>
    /// Get list of rooms to be cleaned
    /// </summary>
    /// <returns></returns>
    Task<List<Room>> GetRoomsToClean();

    /// <summary>
    /// update rooms
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    Task<Room> UpdateRoom(Room room);
}
