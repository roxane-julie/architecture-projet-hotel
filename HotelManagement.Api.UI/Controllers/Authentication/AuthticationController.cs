using HotelManagement.Application.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Api.UI.Controllers.Authentication;

[ApiController]
[Route("api/v1/auth")]
public class AuthticationController(
    IAuthService authenticationService
    ) : ControllerBase
{

    /// <summary>
    /// Login 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] AuthenticationDto model
        )
    {
        var token = await authenticationService.Authenticate(model);
        return Ok(token);
    }
}
