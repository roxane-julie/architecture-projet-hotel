namespace HotelManagement.Domain.Users;

public interface IUserRepository : IBaseRepository<User>
{
    /// <summary>
    /// Create user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<User> Create(User user);
}
