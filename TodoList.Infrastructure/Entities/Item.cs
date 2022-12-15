namespace TodoList.Infrastructure.Entities;

public class Item : IEntity
{
    public int Id { get; set; }
    public string Data { get; set; }
}