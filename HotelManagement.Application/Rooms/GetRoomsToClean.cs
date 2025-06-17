using HotelManagement.Application.Rooms.Dtos;
using HotelManagement.Domain.Bookings;

namespace HotelManagement.Application.Rooms;

/// <summary>
/// <inheritdoc cref="IGetRoomsToClean"/>
/// </summary>
/// <param name="roomRepository"></param>
public class GetRoomsToClean(
        IRoomRepository roomRepository
    ) : IGetRoomsToClean
{
    public async Task<List<RoomDto>> Handle()
    {
        return (await roomRepository.GetRoomsToClean()).Select(r => new RoomDto()
        {
            Id = r.Id,
            Name = r.Name,
            Type = r.Type,
            IsCleaned = r.IsCleaned,
            LastCleanedDate = r.LastCleanedDate,
            CleanedBy = r.CleanedBy,
            State = r.State,

        }).ToList();
    }
}
