using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Dto;
using WebApp.Services;

namespace WebApp.RazorPages.Pages.Todo
{
    public class EditModel : PageModel
    {
        private readonly TodoItemService _service;

        public EditModel(TodoItemService service)
        {
            _service = service;
        }

        [BindProperty]
        public TodoItemDto TodoItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            TodoItem = await _service.GetByIdAsync(id.Value);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.UpdateAsync(TodoItem);

            return RedirectToPage("./Index");
        }
    }
}
