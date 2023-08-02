using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.RazorPages.Data;
using WebApp.RazorPages.Models;

namespace WebApp.RazorPages.Pages.Records
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Record Record { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == default || _context.Records == null)
            {
                return NotFound();
            }

            var record = await _context.Records.FirstOrDefaultAsync(m => m.Id == id);

            if (record == null)
            {
                return NotFound();
            }
            else
            {
                Record = record;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == default || _context.Records == null)
            {
                return NotFound();
            }
            var record = await _context.Records.FindAsync(id);

            if (record != null)
            {
                Record = record;
                _context.Records.Remove(Record);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
