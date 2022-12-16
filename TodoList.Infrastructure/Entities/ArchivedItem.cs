namespace TodoList.Infrastructure.Entities;

public class ArchivedItem : IEntity
{
    public int Id { get; set; }
    public string Data { get; set; }
    public bool IsCompleted { get; set; }
}