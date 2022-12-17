namespace TodoList.Services.Areas.Archive.Dto;

public class ArchivedDto : EntityDto
{
    public string Data { get; set; }
    public bool IsCompleted { get; set; }
}