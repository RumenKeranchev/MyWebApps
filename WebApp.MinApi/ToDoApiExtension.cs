using WebApp.Models.Dto;
using WebApp.Models.ViewFilter;
using WebApp.Services;

namespace WebApp.MinApi
{
    public static class ToDoApiExtension
    {
        public static void MapTodoApi(this WebApplication app)
        {
            var todoItems = app.MapGroup("todoItems");

            todoItems.MapGet("/", GetAllToDos);

            todoItems.MapGet("/complete", GetCompletedToDos);

            todoItems.MapGet("/{id}", GetById);

            todoItems.MapPost("/", Create);

            todoItems.MapPut("/{id}", Update);

            todoItems.MapDelete("/{id}", Delete);
        }

        private static async Task<IResult> GetAllToDos(TodoItemService service)
            => TypedResults.Ok(await service.GetAllAsync(new TodoItemsFilter()));

        private static async Task<IResult> GetCompletedToDos(TodoItemService service)
            => TypedResults.Ok(await service.GetAllAsync(new TodoItemsFilter() { IsCompleted = true }));

        private static async Task<IResult> GetById(long id, TodoItemService service)
        {
            try
            {
                var item = await service.GetById(id);
                return Results.Ok(item);
            }
            catch (ArgumentException)
            {
                return Results.BadRequest();
            }
            catch (NullReferenceException)
            {
                return Results.NotFound(id);
            }
        }

        private static async Task<IResult> Create(TodoItemDto dto, TodoItemService service)
        {
            try
            {
                var id = await service.Insert(dto);
                return Results.Created($"/{id}", null);
            }
            catch (ArgumentNullException)
            {
                return Results.BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private static async Task<IResult> Update(TodoItemDto dto, TodoItemService service)
        {
            try
            {
                await service.Update(dto);
                return Results.NoContent();
            }
            catch (NullReferenceException)
            {
                return Results.BadRequest();
            }
            catch (ArgumentException)
            {
                return Results.BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private static async Task<IResult> Delete(long id, TodoItemService service)
        {
            try
            {
                await service.Delete(id);
                return Results.NoContent();
            }
            catch (NullReferenceException)
            {
                return Results.NotFound();
            }
            catch (ArgumentException)
            {
                return Results.BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
