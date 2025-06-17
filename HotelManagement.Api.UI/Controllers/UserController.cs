using HotelManagement.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Api.UI.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController : HotelManagementControllerBase
{
    public UserController()
    {

    }

    /// <summary>
    /// Create user
    /// </summary>
    /// <param name="userModel"></param>
    /// <param name="createUser"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser(
        [FromBody] UserDto userModel,
        [FromServices] ICreateUser createUser)
    {
        return Ok(await createUser.Handle(userModel));
    }
}
