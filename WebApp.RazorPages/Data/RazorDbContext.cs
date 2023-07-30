﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.RazorPages.Models;

namespace WebApp.RazorPages.Data
{
    public class RazorDbContext : DbContext
    {
        public RazorDbContext (DbContextOptions<RazorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = default!;
    }
}
