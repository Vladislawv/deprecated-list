using TodoList.Services.Areas.Archive.Dto;

namespace TodoList.Services.Areas.Archive;

public interface IArchiveService
{
    public Task<IList<ArchivedDto>> GetListAsync();
    public Task<ArchivedDto> GetByIdAsync(int id);
    public Task<int> ArchiveByIdAsync(int id);
    public Task DeleteByIdAsync(int id);
}