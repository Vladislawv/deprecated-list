using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure;
using TodoList.Infrastructure.Entities;
using TodoList.Services.Areas.Archive.Dto;
using TodoList.Services.Exceptions;

namespace TodoList.Services.Areas.Archive;

public class ArchiveService : IArchiveService
{
    private readonly TodoListContext _context;
    private readonly IMapper _mapper;

    public ArchiveService(TodoListContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<ArchivedDto>> GetListAsync()
    {
        var archivedItems = await _context.ArchivedItems
            .ProjectTo<ArchivedDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return archivedItems;
    }

    public async Task<ArchivedDto> GetByIdAsync(int id)
    {
        var archivedItem = await _context.ArchivedItems
            .ProjectTo<ArchivedDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new NotFoundException($"Archived item with Id:{id} is not found!");

        return archivedItem;
    }

    public async Task<int> ArchiveByIdAsync(int id)
    {
        var item = await _context.Items
            .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new NotFoundException($"Item with Id:{id} is not found!");

        var archivedItem = _mapper.Map<ArchivedItem>(item);

        _context.Items.Remove(item);

        await _context.ArchivedItems.AddAsync(archivedItem);
        await _context.SaveChangesAsync();

        return archivedItem.Id;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var archivedItem = await _context.ArchivedItems
            .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new NotFoundException($"Archived item with Id:{id} is not found!");

        _context.ArchivedItems.Remove(archivedItem);
        await _context.SaveChangesAsync();
    }
}