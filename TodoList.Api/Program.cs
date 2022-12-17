using Microsoft.EntityFrameworkCore;
using TodoList.Api.Middlewares;
using TodoList.Infrastructure;
using TodoList.Services.Areas;
using TodoList.Services.Areas.Archive;
using TodoList.Services.Areas.Items;
using TodoList.Services.Areas.UnArchive;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TodoListContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoListDatabase")));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(EntityDto));

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IItemService, ItemService>();

builder.Services.AddTransient<IArchiveService, ArchiveService>();

builder.Services.AddTransient<IUnArchiveService, UnArchiveService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();