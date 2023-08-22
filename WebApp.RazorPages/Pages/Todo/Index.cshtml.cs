using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Database;
using WebApp.Models.Dto;
using WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewFilter;

namespace WebApp.RazorPages.Pages.Todo
{
    public class IndexModel : PageModel
    {
        private readonly TodoItemService _service;

        public IndexModel(TodoItemService service)
        {
            _service = service;
        }

        public IList<WebApp.Models.Dto.TodoItemDto> TodoItems { get; set; } = default!;

        public async Task OnGetAsync(TodoItemsFilter filter)
            => TodoItems = await _service.GetAsync(filter);
    }
}
