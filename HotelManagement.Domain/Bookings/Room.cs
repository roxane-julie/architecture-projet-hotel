using HotelManagement.Domain.Bookings.Enums;

namespace HotelManagement.Domain.Bookings;

public class Room : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Person { get; set; }
    public RoomType Type { get; set; }
    public bool IsCleaned { get; set; }
    public DateTime? LastCleanedDate { get; set; }
    public Guid CleanedBy { get; set; }
    public float Price { get; set; }
    public RoomStateType State { get; set; }
}
