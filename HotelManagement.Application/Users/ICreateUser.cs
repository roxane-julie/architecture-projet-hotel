namespace HotelManagement.Application.Users;

public interface ICreateUser
{
    public Task<UserDto> Handle(UserDto user);
}
