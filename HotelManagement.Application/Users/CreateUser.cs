using HotelManagement.Domain.Users;

namespace HotelManagement.Application.Users;

public class CreateUser(
    IUserRepository userRepository
    ) : ICreateUser
{
    public async Task<UserDto> Handle(UserDto userDto)
    {
        User user = new()
        {
            EmailAddress = userDto.EmailAddress,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            HashedPassword = userDto.HashedPassword,
            Role = userDto.Role,
        };

        user = await userRepository.Create(user);
        userDto.Id = user.Id;
        return userDto;
    }
}
