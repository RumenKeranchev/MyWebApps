using Microsoft.EntityFrameworkCore;
using WebApp.Models.Database;
using WebApp.Models.Dto;
using WebApp.Models.ViewFilter;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class TodoItemService : BaseService<TodoItemDto, TodoItem>
    {
        public TodoItemService(IRepo<TodoItem> repo) : base(repo)
        {
        }

        public override async Task Delete(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Invalid Id provided for deletion!");
            }

            try
            {
                await Repository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<TodoItemDto>> GetAllAsync(IFilter filter)
        {
            var query = Repository.GetAllQueryable();

            var casted = filter as TodoItemsFilter;

            if (!string.IsNullOrWhiteSpace(casted!.Name))
            {
                query = Repository.FindAllQueryable(i => i.Name.Contains(casted.Name));
            }
            if (casted.Priority.HasValue)
            {
                query = Repository.FindAllQueryable(i => i.Priority == casted.Priority.Value);
            }

            return await query
                .Select(i => new TodoItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsCompleted = i.IsComplete
                })
                .ToListAsync();
        }

        public override Task<TodoItemDto?> GetById(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Invalid Id provided for retrieval!");
            }

            var item = Repository
                .GetAllQueryable()
                .Where(i => i.Id.Equals(id))
                .Select(i => new TodoItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsCompleted = i.IsComplete
                })
                .FirstOrDefaultAsync();

            return item is null
                ? throw new NullReferenceException($"Item with Id [{id}] not found!")
                : item;
        }

        public override async Task<long> Insert(TodoItemDto entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new ArgumentNullException($"Attempted to insert item without name!");
            }

            var todoItem = new TodoItem
            {
                Name = entity.Name,
                IsComplete = entity.IsCompleted
            };

            try
            {
                return await Repository.InsertAsync(todoItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task Update(TodoItemDto entity)
        {
            if (entity is null)
            {
                throw new NullReferenceException($"Attempted to update item without providing any information to update!");
            }

            if (entity.Id <= 0)
            {
                throw new ArgumentException("Attempted to update item an invalid Id!");
            }

            var itemId = await Repository.FindAllQueryable(x => x.Id == entity.Id).Select(x => x.Id).FirstOrDefaultAsync();

            if (itemId == default)
            {
                throw new NullReferenceException($"Attempted to update non-existent item [{entity.Id}]");
            }

            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new ArgumentException($"Attempted to change item [{entity.Id}] with invalid name.");
            }

            var item = new TodoItem { Id = entity.Id, Name = entity.Name, IsComplete = entity.IsCompleted };
            await Repository.UpdateAsync(item);
        }

        public async Task ChangePriority(int id, int priority)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Attempted to change priority for item with an invalid Id!");
            }

            var item = await Repository.GetByIdAsync(id);

            if (item is null)
            {
                throw new NullReferenceException($"Attempted to change priority for non-existent item [{id}]");
            }

            var parsedPriority = Enum.TryParse(priority.ToString(), true, out Priority parsed);

            if (!parsedPriority)
            {
                throw new ArgumentOutOfRangeException($"Attempted to change priority for item [{id}] with an invalid one [{priority}]");
            }

            item.Priority = parsed;
        }
    }
}
