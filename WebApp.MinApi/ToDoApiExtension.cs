namespace WebApp.MinApi
{
    public static class ToDoApiExtension
    {
        public static IEndpointRouteBuilder MapTodoApi(this WebApplication app)
        {
            var todoItems = app.MapGroup("todoItems");

            todoItems.MapGet("/", GetAllToDos);

            todoItems.MapGet("/complete", async (TodoDb db) =>
                await db.Todos.Where(t => t.IsComplete).ToListAsync());

            todoItems.MapGet("/{id}", async (int id, TodoDb db) =>
                await db.Todos.FindAsync(id)
                    is Todo todo
                        ? Results.Ok(todo)
                        : Results.NotFound());

            todoItems.MapPost("/", async (Todo todo, TodoDb db) =>
            {
                db.Todos.Add(todo);
                await db.SaveChangesAsync();

                return Results.Created($"/{todo.Id}", todo);
            });

            todoItems.MapPut("/{id}", async (int id, Todo inputTodo, TodoDb db) =>
            {
                var todo = await db.Todos.FindAsync(id);

                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            todoItems.MapDelete("/{id}", async (int id, TodoDb db) =>
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    db.Todos.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });

            return todoItems;
        }

        private static async Task<IResult> GetAllToDos(TodoDb db)
            => TypedResults.Ok(await db.Todos.ToListAsync());
    }
}
