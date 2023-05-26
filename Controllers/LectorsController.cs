using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PXLApp.Models;
using PXLApp3.Data;

namespace PXLApp3.Controllers
{
    public class LectorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lectors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.lectors.Include(l => l.Gebruiker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.lectors == null)
            {
                return NotFound();
            }

            var lector = await _context.lectors
                .Include(l => l.Gebruiker)
                .FirstOrDefaultAsync(m => m.LectorId == id);
            if (lector == null)
            {
                return NotFound();
            }

            return View(lector);
        }

        // GET: Lectors/Create
        public IActionResult Create()
        {
            ViewData["GebruikerId"] = new SelectList(_context.gebruikers, "GebruikerId", "Email");
            return View();
        }

        // POST: Lectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LectorId,GebruikerId")] Lector lector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage)
                                          .ToList();
            // Inspect the error messages
            Console.WriteLine(string.Join(", ", errorMessages));

            ViewData["GebruikerId"] = new SelectList(_context.gebruikers, "GebruikerId", "Email", lector.GebruikerId);
            return View(lector);
        }

        // GET: Lectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.lectors == null)
            {
                return NotFound();
            }

            var lector = await _context.lectors.FindAsync(id);
            if (lector == null)
            {
                return NotFound();
            }
            ViewData["GebruikerId"] = new SelectList(_context.gebruikers, "GebruikerId", "Email", lector.GebruikerId);
            return View(lector);
        }

        // POST: Lectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LectorId,GebruikerId")] Lector lector)
        {
            if (id != lector.LectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectorExists(lector.LectorId))
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
            ViewData["GebruikerId"] = new SelectList(_context.gebruikers, "GebruikerId", "Email", lector.GebruikerId);
            return View(lector);
        }

        // GET: Lectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.lectors == null)
            {
                return NotFound();
            }

            var lector = await _context.lectors
                .Include(l => l.Gebruiker)
                .FirstOrDefaultAsync(m => m.LectorId == id);
            if (lector == null)
            {
                return NotFound();
            }

            return View(lector);
        }

        // POST: Lectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.lectors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.lectors'  is null.");
            }
            var lector = await _context.lectors.FindAsync(id);
            if (lector != null)
            {
                _context.lectors.Remove(lector);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectorExists(int id)
        {
          return (_context.lectors?.Any(e => e.LectorId == id)).GetValueOrDefault();
        }
    }
}
