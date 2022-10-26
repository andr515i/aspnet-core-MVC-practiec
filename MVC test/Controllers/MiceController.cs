using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_test.Data;
using MVC_test.Models;

namespace MVC_test.Controllers
{
    public class MiceController : Controller
    {
        private readonly MVC_testContext _context;

        public MiceController(MVC_testContext context)
        {
            _context = context;
        }

        // GET: Mice
        public async Task<IActionResult> Index(string mouseRating, string searchString)
        {
            //LINQ to get list of ratings
            IQueryable<int?> ratingQuery = from m in _context.Mice
                                            orderby m.Rating
                                            select (int?)m.Rating;

            var mice = from m in _context.Mice select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                mice = mice.Where(s => s.Name!.Contains(searchString));
            }
             if (!String.IsNullOrEmpty(mouseRating))
            {
                mice = mice.Where(x => x.Rating.ToString() == mouseRating);
            }
            var mouseRatingVM = new MouseRatingViewModel
            {
                Ratings = new SelectList(await ratingQuery.Distinct().ToListAsync()),
                Mice = await mice.ToListAsync()
            };
            return View(mouseRatingVM);
        }

        // GET: Mice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mice == null)
            {
                return NotFound();
            }

            var mice = await _context.Mice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mice == null)
            {
                return NotFound();
            }

            return View(mice);
        }

        // GET: Mice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rating,ReleaseDate,Price,Company")] Mice mice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mice);
        }

        // GET: Mice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mice == null)
            {
                return NotFound();
            }

            var mice = await _context.Mice.FindAsync(id);
            if (mice == null)
            {
                return NotFound();
            }
            return View(mice);
        }

        // POST: Mice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rating,ReleaseDate,Price,Company")] Mice mice)
        {
            if (id != mice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiceExists(mice.Id))
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
            return View(mice);
        }

        // GET: Mice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mice == null)
            {
                return NotFound();
            }

            var mice = await _context.Mice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mice == null)
            {
                return NotFound();
            }

            return View(mice);
        }

        // POST: Mice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mice == null)
            {
                return Problem("Entity set 'MVC_testContext.Mice'  is null.");
            }
            var mice = await _context.Mice.FindAsync(id);
            if (mice != null)
            {
                _context.Mice.Remove(mice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiceExists(int id)
        {
          return _context.Mice.Any(e => e.Id == id);
        }
    }
}
