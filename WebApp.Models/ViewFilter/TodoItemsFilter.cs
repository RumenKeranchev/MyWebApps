using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Database;
using WebApp.Models.Dto;

namespace WebApp.Models.ViewFilter
{
    public class TodoItemsFilter : IFilter<TodoItem>
    {
        private long id;

        public long Id { get => id; set => id = value; }

        public string? Name { get; set; }

        public bool? IsCompleted { get; set; }

        public Priority? Priority { get; set; }

        public IEnumerable<Expression<Func<TodoItem, bool>>> Get()
        {
            var filters = new List<Expression<Func<TodoItem, bool>>>();

            if (!string.IsNullOrWhiteSpace(Name))
            {
                filters.Add((item) => item.Name.Contains(Name));
            }
            if (IsCompleted.HasValue)
            {
                filters.Add((item) => item.IsComplete == IsCompleted);
            }

            return filters;
        }
    }
}
