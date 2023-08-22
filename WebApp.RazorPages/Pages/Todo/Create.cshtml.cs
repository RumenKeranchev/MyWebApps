using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Database;
using WebApp.Models.Database;
using WebApp.Models.Dto;
using WebApp.Services;

namespace WebApp.RazorPages.Pages.Todo
{
    public class CreateModel : PageModel
    {
        private readonly TodoItemService _service;

        public CreateModel(TodoItemService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TodoItemDto TodoItem { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || TodoItem == null)
            {
                return Page();
            }

            await _service.InsertAsync(TodoItem);

            return RedirectToPage("./Index");
        }
    }
}
