using TodoList.Infrastructure.Entities;
using TodoList.Services.Areas.Archive.Dto;

namespace TodoList.Services.Areas.Archive;

public interface IArchiveService
{
    public Task<IList<ArchivedDto>> GetListAsync();
    public Task ArchiveAsync(Item item);
    public Task<int> UnArchiveByIdAsync(int id);
    public Task DeleteByIdAsync(int id);
}