using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.RazorPages.Models;

namespace WebApp.RazorPages.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = default!;

        public DbSet<Record> Records { get; set; } = default!;
    }
}
