namespace HotelManagement.Application.Authentication;

public interface IAuthService
{
    /// <summary>
    /// Login a user
    /// </summary>
    /// <param name="authenticationDto"></param>
    /// <returns></returns>
    Task<AuthenticationResponseDto> Authenticate(AuthenticationDto authenticationDto);
}
