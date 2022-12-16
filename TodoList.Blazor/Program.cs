using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure;
using TodoList.Services.Areas;
using TodoList.Services.Areas.Archive;
using TodoList.Services.Areas.Items;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoListContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoListDatabase")));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAutoMapper(typeof(EntityDto));

builder.Services.AddTransient<IItemService, ItemService>();

builder.Services.AddTransient<IArchiveService, ArchiveService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();