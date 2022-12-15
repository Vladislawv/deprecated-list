using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Areas.Items;
using TodoList.Services.Areas.Items.Dto;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("api/items")]
[Produces(MediaTypeNames.Application.Json)]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<ItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListAsync()
    {
        var items = await _itemService.GetListAsync();

        return Ok(items);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var item = await _itemService.GetByIdAsync(id);

        return Ok(item);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] ItemDtoInput itemInput)
    {
        var itemId = await _itemService.CreateAsync(itemInput);
        var item = await _itemService.GetByIdAsync(itemId);

        return Ok(item);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateByIdAsync([FromRoute] int id, [FromBody] ItemDtoInput itemInput)
    {
        var itemId = await _itemService.UpdateByIdAsync(id, itemInput);
        var item = await _itemService.GetByIdAsync(itemId);

        return Ok(item);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
    {
        await _itemService.DeleteByIdAsync(id);

        return Ok();
    }
}