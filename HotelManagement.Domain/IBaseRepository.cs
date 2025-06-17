namespace HotelManagement.Domain;

public interface IBaseRepository<T> where T : IEntity
{
    /// <summary>
    /// Get T
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetAsync(Guid id);
}
