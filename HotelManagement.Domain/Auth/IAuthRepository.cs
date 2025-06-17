using HotelManagement.Domain.Users;

namespace HotelManagement.Domain.Auth;

public interface IAuthRepository
{
    /// <summary>
    ///  auth user
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<User?> AuthUser(string email, string password);
}
