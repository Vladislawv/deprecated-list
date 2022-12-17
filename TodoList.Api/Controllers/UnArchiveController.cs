using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Areas.Items;
using TodoList.Services.Areas.Items.Dto;
using TodoList.Services.Areas.UnArchive;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("api/unarchive")]
[Produces(MediaTypeNames.Application.Json)]
public class UnArchiveController : ControllerBase
{
    private readonly IUnArchiveService _unArchiveService;
    private readonly IItemService _itemService;

    public UnArchiveController(IUnArchiveService unArchiveService, IItemService itemService)
    {
        _unArchiveService = unArchiveService;
        _itemService = itemService;
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(ItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UnArchiveByIdAsync([FromRoute] int id)
    {
        var itemId = await _unArchiveService.UnArchiveByIdAsync(id);
        var item = await _itemService.GetByIdAsync(itemId);

        return Ok(item);
    }
}