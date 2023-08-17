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

        public override IQueryable<TodoItem> GetAllFilteredQueryable(Expression<Func<TodoItem, bool>> filter)
            => _context.ToDoItems.Where(filter);

        public override async Task<List<TodoItem>> GetAllAsync()
            => await _context.ToDoItems.ToListAsync();

        public override async Task<List<TodoItem>> GetAllFilteredAsync(Expression<Func<TodoItem, bool>> filter)
            => await _context.ToDoItems.Where(filter).ToListAsync();

        public override IQueryable<TodoItem> GetAllQueryable()
            => _context.ToDoItems.AsQueryable();

        public override async Task<TodoItem?> GetByIdAsync(long id)
            => await _context.ToDoItems.FindAsync(id);

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
