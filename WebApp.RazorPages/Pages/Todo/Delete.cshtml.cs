using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Dto;
using WebApp.Services;

namespace WebApp.RazorPages.Pages.Todo
{
    public class DeleteModel : PageModel
    {
        private readonly TodoItemService _service;

        public DeleteModel(TodoItemService service)
        {
            _service = service;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            await _service.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
