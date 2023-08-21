using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Database;
using WebApp.Models.Dto;
using WebApp.Models.ViewFilter;
using WebApp.Services;

namespace WebApp.MVC.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly TodoItemService _service;

        public TodoItemsController(AppDbContext context, TodoItemService service)
        {
            _context = context;
            _service = service;
        }

        // GET: TodoItems
        public async Task<IActionResult> Index(string? name = null, bool? isCompleted = null)
        {
            var items = await _service.GetAllAsync(new TodoItemsFilter() { Name = name, IsCompleted = isCompleted });
            return View(items);
        }

        // GET: TodoItems/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var todoItem = await _service.GetByIdAsync(id.Value);
                return View(todoItem);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        // GET: TodoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsComplete")] TodoItemDto todoItem)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _service.InsertAsync(todoItem);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View(todoItem);
        }

        // GET: TodoItems/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var todoItem = await _service.GetByIdAsync(id.Value);
                return View(todoItem);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        // POST: TodoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsComplete")] TodoItemDto todoItem)
        {
            if (id != todoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(todoItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemExists(todoItem.Id))
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
            return View(todoItem);
        }

        // GET: TodoItems/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ToDoItems == null)
            {
                return NotFound();
            }

            try
            {
                var todoItem = await _service.GetByIdAsync(id.Value);
                return View(todoItem);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        private bool TodoItemExists(long id)
        {
            return (_context.ToDoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
