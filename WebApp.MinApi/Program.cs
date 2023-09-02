using Microsoft.Extensions.Options;
using WebApp.Database;
using WebApp.MinApi;
using WebApp.Models.Database;
using WebApp.Repositories;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped(typeof(IRepo<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRepo<TodoItem>, TodoItemsRepo>();
builder.Services.AddScoped<TodoItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI((opt) =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opt.RoutePrefix = string.Empty;
    });
}

app.MapTodoApi();

app.Run();
