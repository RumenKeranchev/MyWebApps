using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.MVC.Models;

namespace WebApp.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            //if (_context.Movies == null)
            //{
            //    return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            //}

            //var genres = await _context.Movies
            //    .Select(m => m.Genre)
            //    .Distinct()
            //    .ToListAsync();

            //var movies = _context.Movies.AsQueryable();

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    movies = movies.Where(s => s.Title!.Contains(searchString));
            //}

            //if (!string.IsNullOrEmpty(movieGenre))
            //{
            //    movies = movies.Where(x => x.Genre == movieGenre);
            //}

            //var movieGenreVM = new MovieGenreViewModel
            //{
            //    Genres = new SelectList(genres),
            //    Movies = await movies.ToListAsync()
            //};

            return View(new MovieGenreViewModel());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.Movies == null)
            //{
            //    return NotFound();
            //}

            //var movie = await _context.Movies
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            return View(new Movie());
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.Movies == null)
            //{
            //    return NotFound();
            //}

            //var movie = await _context.Movies.FindAsync(id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}
            return View(new Movie());
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.Movies == null)
            //{
            //    return NotFound();
            //}

            //var movie = await _context.Movies
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            return View(new Movie());
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.Movies == null)
            //{
            //    return Problem("Entity set 'AppDbContext.Movie'  is null.");
            //}
            //var movie = await _context.Movies.FindAsync(id);
            //if (movie != null)
            //{
            //    _context.Movies.Remove(movie);
            //}

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            //return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
            return false;
        }
    }
}
