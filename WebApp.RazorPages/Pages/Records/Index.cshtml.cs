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
    public class IndexModel : PageModel
    {
        private readonly RazorDbContext _context;

        public IndexModel(RazorDbContext context)
        {
            _context = context;
        }

        public IList<Record> Record { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Records != null)
            {
                Record = await _context.Records.ToListAsync();
            }
        }
    }
}
