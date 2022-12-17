using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure.Entities;

namespace TodoList.Infrastructure;

public class TodoListContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<ArchivedItem> ArchivedItems { get; set; }
    
    public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
    {
    }
}