﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.RazorPages.Data;
using WebApp.RazorPages.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.RazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorDbContext _context;

        public IndexModel(RazorDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public IList<Movie> Movies { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var movies = _context.Movies.AsQueryable();
            var genres = await movies
                .Select(m => m.Genre)
                .Distinct()
                .ToListAsync();

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(m => m.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(m => m.Genre == MovieGenre);
            }

            Movies = await movies.ToListAsync();
            Genres = new SelectList(genres);
        }
    }
}
