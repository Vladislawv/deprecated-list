using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure;
using TodoList.Infrastructure.Entities;
using TodoList.Services.Exceptions;

namespace TodoList.Services.Areas.UnArchive;

public class UnArchiveService : IUnArchiveService
{
    private readonly TodoListContext _context;
    private readonly IMapper _mapper;

    public UnArchiveService(TodoListContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> UnArchiveByIdAsync(int id)
    {
        var archivedItem = await _context.ArchivedItems
            .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new NotFoundException($"Archived item with Id:{id} is not found!");

        var item = _mapper.Map<Item>(archivedItem);
        
        _context.ArchivedItems.Remove(archivedItem);
        
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();

        return item.Id;
    }
}