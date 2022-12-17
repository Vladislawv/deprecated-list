using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Areas.Archive;
using TodoList.Services.Areas.Archive.Dto;
using TodoList.Services.Areas.Items;
using TodoList.Services.Areas.Items.Dto;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("api/archive")]
[Produces(MediaTypeNames.Application.Json)]
public class ArchiveController : ControllerBase
{
    private readonly IArchiveService _archiveService;
    private readonly IItemService _itemService;

    public ArchiveController(IArchiveService archiveService, IItemService itemService)
    {
        _archiveService = archiveService;
        _itemService = itemService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<ArchivedDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListAsync()
    {
        var archivedItems = await _archiveService.GetListAsync();

        return Ok(archivedItems);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ArchivedDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var archivedItem = await _archiveService.GetByIdAsync(id);

        return Ok(archivedItem);
    }

    [HttpPost("{id:int}")]
    [ProducesResponseType(typeof(ArchivedDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> ArchiveByIdAsync([FromRoute] int id)
    {
        var archivedItemId = await _archiveService.ArchiveByIdAsync(id);
        var archivedItem = await _archiveService.GetByIdAsync(archivedItemId);

        return Ok(archivedItem);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
    {
        await _archiveService.DeleteByIdAsync(id);

        return Ok();
    }
}