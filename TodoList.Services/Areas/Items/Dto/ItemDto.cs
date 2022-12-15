namespace TodoList.Services.Areas.Items.Dto;

public class ItemDto : EntityDto
{
    public string Data { get; set; }
    public bool IsCompleted { get; set; }
}