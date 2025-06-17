using HotelManagement.Application.Authentication;
using HotelManagement.Domain.Auth;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace HotelManagement.Api.UI.Controllers.Authentication;

/// <inheritdoc cref="ICurrentUserTokenAdapter" />
public class CurrentUserTokenAdapter(
        IHttpContextAccessor httpContextAccessor,
        IOptions<JwtBearerOption> jwtTokenOption
    ) : ICurrentUserTokenAdapter
{
    private readonly JwtBearerOption _jwtTokenOption = jwtTokenOption.Value;

    public string? GetValueKey(string key)
    {
        HttpContext? context = httpContextAccessor.HttpContext;
        if (context == null)
        {
            return null;
        }
        return context.User.FindFirst(key)?.Value;
    }

    public List<string>? GetValuesKey(string key)
    {
        HttpContext? context = httpContextAccessor.HttpContext;
        if (context == null)
        {
            return null;
        }
        IEnumerable<Claim> claims = context.User.FindAll(key);
        return claims.Select(c => c.Value).ToList<string>();
    }

    public string? GetUserFullName() => GetValueKey("nameid");

    public Guid? GetUserId()
    {
        _ = Guid.TryParse(GetValueKey("Id"), out Guid userId);
        return userId;
    }

    public string? GetUserEmail() => GetValueKey(ClaimTypes.Email);

    public string? GetUserNameIdentifier() => GetValueKey(ClaimTypes.NameIdentifier);

    public string GetUserRole() => GetValueKey(ClaimTypes.Role)!;
}
