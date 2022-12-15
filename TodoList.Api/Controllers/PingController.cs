using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("api/ping")]
[Produces(MediaTypeNames.Application.Json)]
public class PingController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IActionResult> PingAsync()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}