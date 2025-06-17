using HotelManagement.Application.Rooms.Dtos;

namespace HotelManagement.Application.Rooms;

public interface IGetAvailableRooms
{
    /// <summary>
    /// Get avaibable room data 
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="roleType"></param>
    /// <returns></returns>
    Task<List<RoomDto>> Handle(DateTime from, DateTime to, string roleType);
}
