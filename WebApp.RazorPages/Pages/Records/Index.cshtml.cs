using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.RazorPages.Models;

namespace WebApp.RazorPages.Pages.Records
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Record> Record { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.Records != null)
            //{
            //    Record = await _context.Records.ToListAsync();
            //}
        }
    }
}
