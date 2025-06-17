namespace HotelManagement.Application.Rooms;

public interface IPatchCleanedRoom
{
    Task Handle(Guid roomId);
}
