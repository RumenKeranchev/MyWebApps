using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using WebApp.Database;
using WebApp.Models.Database;

namespace WebApp.Repositories
{
    public class TodoItemsRepo : BaseRepo<TodoItem>
    {
        private readonly AppDbContext _context;

        public TodoItemsRepo(AppDbContext context)
        {
            _context = context;
        }

        public override async Task DeleteAsync(long id)
        {
            var item = await _context.ToDoItems.FirstAsync(i => i.Id == id);
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public override Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TodoItem, TResult>> selector, Expression<Func<TodoItem, bool>> filter) where TResult : class
            => _context
               .ToDoItems
               .Where(filter)
               .Select(selector)
               .ToListAsync();

        public override Task<TResult?> GetByIdAsync<TResult>(long id, Expression<Func<TodoItem, TResult>> selector) where TResult : class
            => _context.ToDoItems
                .Where(i => i.Id == id)
                .Select(selector)
                .SingleOrDefaultAsync();

        public override async Task<long> InsertAsync(TodoItem entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        /// <summary>
        /// If some property is not set, it will be reset - THIS NEEDS A FIX
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override async Task UpdateAsync(TodoItem entity)
        {
            var item = await _context.ToDoItems.FirstAsync(x => x.Id == entity.Id);

            var x = _context.Entry(entity).Properties.Where(p => p.IsModified).ToList();

            foreach (var prop in entity.GetType().GetProperties())
            {
                var value = prop.GetValue(entity);
                var itemProp = item.GetType().GetProperty(prop.Name);

                if (value != default && itemProp!.GetValue(item) != value)
                {
                    itemProp.SetValue(item, value);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
