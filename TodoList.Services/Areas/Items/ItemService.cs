using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure;
using TodoList.Infrastructure.Entities;
using TodoList.Services.Areas.Items.Dto;
using TodoList.Services.Exceptions;

namespace TodoList.Services.Areas.Items;

public class ItemService : IItemService
{
    private readonly TodoListContext _context;
    private readonly IMapper _mapper;

    public ItemService(TodoListContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<ItemDto>> GetListAsync()
    {
        var items = await _context.Items
            .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return items;
    }

    public async Task<ItemDto> GetByIdAsync(int id)
    {
        var item = await _context.Items
            .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new NotFoundException($"Item with Id:{id} is not found!");

        return item;
    }

    public async Task<int> CreateAsync(ItemDtoInput itemInput)
    {
        var item = _mapper.Map<Item>(itemInput);

        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();

        return item.Id;
    }

    public async Task<int> UpdateByIdAsync(int id, ItemDtoInput itemInput)
    {
        var item = await _context.Items
            .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new NotFoundException($"Item with Id:{id} is not found !");

        _mapper.Map(itemInput, item);

        _context.Items.Update(item);
        await _context.SaveChangesAsync();

        return item.Id;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var item = await _context.Items
            .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new NotFoundException($"Item with Id:{id} is not found !");

        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
    }
}