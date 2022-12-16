using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure;
using TodoList.Infrastructure.Entities;
using TodoList.Services.Areas.Archive.Dto;

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

    public async Task ArchiveAsync(Item item)
    {
        var archivedItem = _mapper.Map<ArchivedItem>(item);
        
        _context.Items.Remove(item);
        
        _context.ArchivedItems.Add(archivedItem);
        await _context.SaveChangesAsync();
    }

    public async Task<int> UnArchiveByIdAsync(int id)
    {
        var archivedItem = await _context.ArchivedItems
            .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new Exception($"Archived item with Id:{id} is not found!");

        var item = _mapper.Map<Item>(archivedItem);
        
        _context.ArchivedItems.Remove(archivedItem);
        
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();

        return item.Id;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var archivedItem = await _context.ArchivedItems
            .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new Exception($"Archived item with Id:{id} is not found!");

        _context.ArchivedItems.Remove(archivedItem);
        await _context.SaveChangesAsync();
    }
}