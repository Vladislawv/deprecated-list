using TodoList.Services.Areas.Items.Dto;

namespace TodoList.Services.Areas.Items;

public interface IItemService
{
    public Task<IList<ItemDto>> GetListAsync();
    public Task<ItemDto> GetByIdAsync(int id);
    public Task<int> CreateAsync(ItemDtoInput itemInput);
    public Task<int> UpdateByIdAsync(int id, ItemDtoInput itemInput);
    public Task DeleteByIdAsync(int id);
}