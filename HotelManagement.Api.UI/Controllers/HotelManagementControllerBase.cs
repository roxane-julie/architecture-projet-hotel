using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Api.UI.Controllers;

[Authorize]
public class HotelManagementControllerBase : ControllerBase
{
}
