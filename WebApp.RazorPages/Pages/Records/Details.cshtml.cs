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
    public class DetailsModel : PageModel
    {
        private readonly RazorDbContext _context;

        public DetailsModel(RazorDbContext context)
        {
            _context = context;
        }

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
    }
}
