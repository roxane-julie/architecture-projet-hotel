using HotelManagement.Domain.Users;

namespace HotelManagement.Infrastructure.Data.Users
{
    /// <summary>
    /// <inheritdoc cref="IUserRepository"/>
    /// </summary>
    public class UserRepository : Context<User>, IUserRepository
    {
        private readonly string path = "./../HotelManagement.Domain/Users/users.json";
        public async Task<User> Create(User user)
        {
            user.Id = Guid.NewGuid();
            user.HashedPassword = PasswordHash.Instance.HashPassword(user, user.HashedPassword);
            await AddData(path, user);
            return user;
        }

        public async Task<User?> GetAsync(Guid id)
        {
            List<User> users = await GetDataJsonFile(path);
            return users.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
