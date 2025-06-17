namespace HotelManagement.Application.Authentication;

/// <summary>
/// Helps retrieving informations about the current user
/// </summary>
public interface ICurrentUserTokenAdapter
{
    /// <summary>
    /// Retrieve a value from its key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string? GetValueKey(string key);

    /// <summary>
    /// Retrieve a list of values from its key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public List<string>? GetValuesKey(string key);

    /// <summary>
    /// User Full name
    /// </summary>
    /// <returns></returns>
    public string? GetUserFullName();

    /// <summary>
    /// User ID
    /// </summary>
    /// <returns></returns>
    public Guid? GetUserId();

    /// <summary>
    /// User email
    /// </summary>
    /// <returns></returns>
    public string? GetUserEmail();

    /// <summary>
    /// Get User NameIdentifier
    /// </summary>
    /// <returns></returns>
    public string? GetUserNameIdentifier();

    /// <summary>
    /// User Roles
    /// </summary>
    /// <returns></returns>
    public string GetUserRole();
}