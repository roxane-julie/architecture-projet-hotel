using HotelManagement.Application.Rooms.Dtos;

namespace HotelManagement.Application.Rooms;

public interface IGetRoomsToClean
{
    /// <summary>
    /// get list of rooms to be cleaned
    /// </summary>
    /// <returns></returns>
    Task<List<RoomDto>> Handle();
}
