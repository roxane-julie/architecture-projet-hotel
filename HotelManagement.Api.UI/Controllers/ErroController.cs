using HotelManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Api.UI.Controllers;

/// <summary>
/// Global handler exception
/// </summary>
public class ErroController : ControllerBase
{
    [Route("/api/v1/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult HandlerError(
        [FromServices] IHostEnvironment hostEnvironment)
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
        if (exception == null)
        {
            return NotFound();
        }

        if (exception.Error is NotFoundException notFound)
            return NotFound(notFound.Message);

        if (exception.Error is BadRequestException badRequest)
            return BadRequest(badRequest.Message);

        if (hostEnvironment.IsDevelopment())
            return Problem(exception.Error.Message, exception.Error.StackTrace);

        return Problem();
    }
}
