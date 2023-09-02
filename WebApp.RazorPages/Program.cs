using WebApp.Database;
using WebApp.Models.Database;
using WebApp.RazorPages.Models;
using WebApp.Repositories;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>();
//builder.Services.AddScoped(typeof(IRepo<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRepo<TodoItem>, TodoItemsRepo>();
builder.Services.AddScoped<TodoItemService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
