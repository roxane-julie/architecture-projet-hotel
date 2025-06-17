using HotelManagement.Application.Authentication;
using HotelManagement.Application.Rooms;
using HotelManagement.Application.Rooms.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Api.UI.Controllers.Rooms;
[ApiController]
[Route("api/v1/rooms")]
public class RoomsController : HotelManagementControllerBase
{
    public RoomsController()
    {

    }

    /// <summary>
    /// Get available rooms
    /// </summary>
    /// <param name="model"></param>
    /// <param name="getAvailableRooms"></param>
    /// <param name="currentUserTokenAdapter"></param>
    /// <returns></returns>
    [HttpGet("available-rooms")]
    [Authorize(Roles = "Receptionist,Customer")]
    public async Task<IActionResult> GetAvailableRooms(
        [FromQuery] GetAvailableRoomsDto model,
        [FromServices] IGetAvailableRooms getAvailableRooms,
        [FromServices] ICurrentUserTokenAdapter currentUserTokenAdapter)
    {
        return Ok(await getAvailableRooms.Handle(model.From, model.To, currentUserTokenAdapter.GetUserRole()));
    }

    /// <summary>
    /// Get list rooms need cleans
    /// </summary>
    /// <param name="getRoomsToClean"></param>
    /// <returns></returns>
    [HttpGet("staff/need-clean")]
    [Authorize(Roles = "Receptionist,CleaningStaff")]
    public async Task<IActionResult> GetRoomsNeedClean(
        [FromServices] IGetRoomsToClean getRoomsToClean)
    {
        return Ok(await getRoomsToClean.Handle());
    }

    /// <summary>
    /// change room to cleaned status
    /// </summary>
    /// <param name="roomid"></param>
    /// <param name="patchCleanedRoom"></param>
    /// <returns></returns>
    [HttpPatch("staff/cleaned/{roomid:Guid}")]
    [Authorize(Roles = "CleaningStaff")]
    public async Task<IActionResult> PatchCleanedRoom(
        Guid roomid,
        [FromServices] IPatchCleanedRoom patchCleanedRoom)
    {
        await patchCleanedRoom.Handle(roomid);
        return Ok();
    }
}
