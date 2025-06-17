
using HotelManagement.Domain.Auth;
using HotelManagement.Domain.Exceptions;
using HotelManagement.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelManagement.Application.Authentication;

/// <summary>
/// <inheritdoc cref="IAuthService">
/// </summary>
/// <param name="authRepository"></param>
/// <param name="options"></param>
public class AuthService(
    IAuthRepository authRepository,
    IOptions<JwtBearerOption> options
    ) : IAuthService
{
    public async Task<AuthenticationResponseDto> Authenticate(AuthenticationDto authenticationDto)
    {
        User? user = await authRepository.AuthUser(authenticationDto.Email, authenticationDto.Password)
            ?? throw new BadRequestException("Email or password invalid");

        AuthenticationResponseDto authenticationResponseDto = new()
        {
            Token = GenerateJwtToken(user)
        };

        return authenticationResponseDto;
    }

    /// <summary>
    /// generate token
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private string GenerateJwtToken(User user)
    {
        JwtBearerOption jwtOptions = options.Value;

        if (!string.IsNullOrWhiteSpace(jwtOptions.Key))
        {
            JwtSecurityTokenHandler jwtTokenHandler = new();

            byte[] key = Encoding.UTF8.GetBytes(jwtOptions.Key);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audience,
                Subject = new ClaimsIdentity(
                [
                    new Claim(type: "Id", value: user.Id.ToString()),
                    new Claim(type: JwtRegisteredClaimNames.Sub, value: user.Id.ToString()),
                    new Claim(type: ClaimTypes.Email, value: user.EmailAddress ?? string.Empty),
                    new Claim(type: ClaimTypes.NameIdentifier, value: user.LastName ?? string.Empty),
                    new Claim(type: ClaimTypes.Role, user.Role.ToString()),
                    new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString())
                ]),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            //Claims roles


            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            string jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        return string.Empty;
    }
}
