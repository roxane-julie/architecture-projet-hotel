using HotelManagement.Application.Rooms.Dtos;
using HotelManagement.Domain.Bookings;
using HotelManagement.Domain.Users;

namespace HotelManagement.Application.Rooms;

/// <summary>
/// <inheritdoc cref="IGetAvailableRooms"/>
/// </summary>
/// <param name="roomRepository"></param>
/// <param name="bookingRepository"></param>
public class GetAvailableRooms(
    IRoomRepository roomRepository,
    IBookingRepository bookingRepository
    ) : IGetAvailableRooms
{

    public async Task<List<RoomDto>> Handle(DateTime from, DateTime to, string roleType)
    {
        List<Guid> roomIds = await bookingRepository.GetUnAvailableRoomsIdsForDate(from, to);
        var rooms = await roomRepository.GetRoomsByUnAvailableIds(roomIds);
        RoomDataFactory factory = new RoomDataFactory();
        return factory.GetRoomsData(rooms, roleType).GetRoomData();
    }
}

#region Factory pattern
public class RoomDataFactory
{
    public RoomData GetRoomsData(List<Room> users, string roleType)
    {
        switch (roleType)
        {
            case nameof(RoleType.Receptionist):
                return new ReceptionistRoomData(users);
            case nameof(RoleType.Customer):
            default:
                return new CustomerRoomData(users);
        }
    }
}
#endregion
public abstract class RoomData(List<Room> rooms)
{
    public abstract List<RoomDto> GetRoomData();
}

public class CustomerRoomData(List<Room> rooms) : RoomData(rooms)
{
    public override List<RoomDto> GetRoomData()
    {
        return rooms.Select(r => new RoomDto
        {
            Id = r.Id,
            Name = r.Name,
            Person = r.Person,
            Price = r.Price,
            Type = r.Type,
        }).ToList();
    }
}
public class ReceptionistRoomData(List<Room> rooms) : RoomData(rooms)
{
    public override List<RoomDto> GetRoomData()
    {
        return rooms.Select(r => new RoomDto
        {
            Id = r.Id,
            Name = r.Name,
            Person = r.Person,
            Price = r.Price,
            Type = r.Type,
            State = r.State,
            CleanedBy = r.CleanedBy,
            IsCleaned = r.IsCleaned,
            LastCleanedDate = r.LastCleanedDate,
        }).ToList();
    }
}

