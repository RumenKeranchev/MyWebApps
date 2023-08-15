using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Database;

namespace WebApp.Models.ViewFilter
{
    public class TodoItemsFilter : IFilter
    {
        private long id;

        public long Id { get => id; set => id = value; }

        public string? Name { get; set; }

        public Priority? Priority { get; set; }
    }
}
