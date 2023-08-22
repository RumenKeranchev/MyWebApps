using System.Linq.Expressions;
using WebApp.Models.Database;

namespace WebApp.Models.Dto
{
    public class TodoItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }

        public static Expression<Func<Database.TodoItem, TodoItemDto>> Selector
        {
            get
            {
                return item => new TodoItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsComplete = item.IsComplete
                };
            }
        }
    }
}
