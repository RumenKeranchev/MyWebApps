using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.RazorPages.Models;

namespace WebApp.RazorPages.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;


        // To protect from over posting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.Movies == null || Movie == null)
            //{
            //    return Page();
            //}

            //_context.Movies.Add(Movie);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
