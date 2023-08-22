using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models.Dto;
using WebApp.Services;

namespace WebApp.RazorPages.Pages.Todo
{
    public class DetailsModel : PageModel
    {
        private readonly TodoItemService _service;

        public DetailsModel(TodoItemService service)
        {
            _service = service;
        }

      public TodoItemDto TodoItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoitem = await _service.GetByIdAsync(id.Value);
            if (todoitem == null)
            {
                return NotFound();
            }
            else 
            {
                TodoItem = todoitem;
            }
            return Page();
        }
    }
}
