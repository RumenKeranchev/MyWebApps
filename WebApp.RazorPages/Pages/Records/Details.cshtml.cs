﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.RazorPages.Models;

namespace WebApp.RazorPages.Pages.Records
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Record Record { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            //if (id == default || _context.Records == null)
            //{
            //    return NotFound();
            //}

            //var record = await _context.Records.FirstOrDefaultAsync(m => m.Id == id);
            //if (record == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    Record = record;
            //}
            return Page();
        }
    }
}
