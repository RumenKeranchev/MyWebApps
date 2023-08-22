﻿using System.Linq.Expressions;
using WebApp.Models.Database;
using WebApp.Models.Dto;
using WebApp.Models.ViewFilter;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class TodoItemService : BaseService<Models.Dto.TodoItemDto, Models.Database.TodoItem>
    {
        public TodoItemService(IRepo<Models.Database.TodoItem> repo) : base(repo)
        {
        }

        public override async Task DeleteAsync(long id)
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

        public override async Task<List<Models.Dto.TodoItemDto>> GetAsync(IFilter<Models.Database.TodoItem> filter)
            => await Repository.GetAsync(Models.Dto.TodoItemDto.Selector, filter.Get());

        public override Task<Models.Dto.TodoItemDto?> GetByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Invalid Id provided for retrieval!");
            }

            var item = Repository.GetByIdAsync(id, Models.Dto.TodoItemDto.Selector);

            return item is null
                ? throw new NullReferenceException($"Item with Id [{id}] not found!")
                : item;
        }

        public override async Task<long> InsertAsync(Models.Dto.TodoItemDto entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new ArgumentNullException($"Attempted to insert item without name!");
            }

            var todoItem = new Models.Database.TodoItem
            {
                Name = entity.Name,
                IsComplete = entity.IsComplete,
                Priority = Priority.Low
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

        public override async Task UpdateAsync(Models.Dto.TodoItemDto entity)
        {
            if (entity is null)
            {
                throw new NullReferenceException($"Attempted to update item without providing any information to update!");
            }

            if (entity.Id <= 0)
            {
                throw new ArgumentException("Attempted to update item an invalid Id!");
            }

            var itemId = await Repository.GetByIdAsync(entity.Id, x => new { x.Id })
                ?? throw new NullReferenceException($"Attempted to update non-existent item [{entity.Id}]");

            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new ArgumentException($"Attempted to change item [{entity.Id}] with invalid name.");
            }

            var item = new Models.Database.TodoItem { Id = entity.Id, Name = entity.Name, IsComplete = entity.IsComplete };
            await Repository.UpdateAsync(item);
        }

        // This is not part of an interface which will cause issues in testing
        public async Task ChangePriority(int id, int priority)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Attempted to change priority for item with an invalid Id!");
            }

            var item = await Repository.GetByIdAsync(id, x => x)
                ?? throw new NullReferenceException($"Attempted to change priority for non-existent item [{id}]");

            var parsedPriority = Enum.TryParse(priority.ToString(), true, out Priority parsed);

            if (!parsedPriority)
            {
                throw new ArgumentOutOfRangeException($"Attempted to change priority for item [{id}] with an invalid one [{priority}]");
            }

            item.Priority = parsed;
        }
    }
}
