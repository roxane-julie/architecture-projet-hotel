using HotelManagement.Domain.Auth;
using HotelManagement.Domain.Exceptions;
using HotelManagement.Domain.Users;
using HotelManagement.Infrastructure.Data.Users;

namespace HotelManagement.Infrastructure.Data.Auth;

/// <summary>
///<inheritdoc cref="IAuthRepository"/>
/// </summary>
public class AuthRepository : Context<User>, IAuthRepository
{
    private readonly string path = "./../HotelManagement.Domain/Users/users.json";
    public async Task<User?> AuthUser(string email, string password)
    {
        List<User> users = await GetDataJsonFile(path);
        User user = users.Where(u => u.EmailAddress == email).FirstOrDefault() ?? throw new BadRequestException("Email or password invalid");
        if (PasswordHash.Instance.VerifyUserHash(user, user.HashedPassword, password))
            return user;

        return null;
    }
}
