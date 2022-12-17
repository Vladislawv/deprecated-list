namespace TodoList.Services.Areas.UnArchive;

public interface IUnArchiveService
{
    public Task<int> UnArchiveByIdAsync(int id);
}