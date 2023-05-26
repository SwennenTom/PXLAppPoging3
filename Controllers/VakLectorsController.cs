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
    public class VakLectorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VakLectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VakLectors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.vakLectoren
                .Include(v => v.Lector).ThenInclude(l => l.Gebruiker)
                .Include(v => v.Vak);
            return View(await applicationDbContext.ToListAsync());
        }
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.vakLectoren.Include(v => v.Lector).Include(v => v.Vak);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: VakLectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.vakLectoren == null)
            {
                return NotFound();
            }

            var vakLector = await _context.vakLectoren
                .Include(v => v.Lector).ThenInclude(u => u.Gebruiker)
                .Include(v => v.Vak)
                .FirstOrDefaultAsync(m => m.VakLectorId == id);

            if (vakLector == null)
            {
                return NotFound();
            }

            return View(vakLector);
        }

        // GET: VakLectors/Create
        public IActionResult Create()
        {
            //ViewData["LectorId"] = new SelectList(_context.lectors, "LectorId", "LectorId");
            ViewData["VakId"] = new SelectList(_context.vakken, "VakId", "VakNaam");
            ViewData["LectorId"] = new SelectList(_context.lectors.Include(l => l.Gebruiker), "LectorId", "Gebruiker.Naam");
            return View();
        }

        // POST: VakLectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VakLectorId,VakId,LectorId")] VakLector vakLector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vakLector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LectorId"] = new SelectList(_context.lectors, "LectorId", "LectorId", vakLector.LectorId);
            ViewData["VakId"] = new SelectList(_context.vakken, "VakId", "VakNaam", vakLector.VakId);
            return View(vakLector);
        }

        // GET: VakLectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.vakLectoren == null)
            {
                return NotFound();
            }

            var vakLector = await _context.vakLectoren.FindAsync(id);
            if (vakLector == null)
            {
                return NotFound();
            }
            //ViewData["LectorId"] = new SelectList(_context.lectors, "LectorId", "LectorId", vakLector.LectorId);
            ViewData["LectorId"] = new SelectList(_context.lectors.Include(l => l.Gebruiker), "LectorId", "Gebruiker.Naam");
            ViewData["VakId"] = new SelectList(_context.vakken, "VakId", "VakNaam", vakLector.VakId);
            return View(vakLector);
        }

        // POST: VakLectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VakLectorId,VakId,LectorId")] VakLector vakLector)
        {
            if (id != vakLector.VakLectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vakLector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakLectorExists(vakLector.VakLectorId))
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
            ViewData["LectorId"] = new SelectList(_context.lectors, "LectorId", "LectorId", vakLector.LectorId);
            ViewData["VakId"] = new SelectList(_context.vakken, "VakId", "VakNaam", vakLector.VakId);
            return View(vakLector);
        }

        // GET: VakLectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.vakLectoren == null)
            {
                return NotFound();
            }

            var vakLector = await _context.vakLectoren
                .Include(v => v.Lector)
                .Include(v => v.Vak)
                .FirstOrDefaultAsync(m => m.VakLectorId == id);
            if (vakLector == null)
            {
                return NotFound();
            }

            return View(vakLector);
        }

        // POST: VakLectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.vakLectoren == null)
            {
                return Problem("Entity set 'ApplicationDbContext.vakLectoren'  is null.");
            }
            var vakLector = await _context.vakLectoren.FindAsync(id);
            if (vakLector != null)
            {
                _context.vakLectoren.Remove(vakLector);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VakLectorExists(int id)
        {
          return (_context.vakLectoren?.Any(e => e.VakLectorId == id)).GetValueOrDefault();
        }
    }
}
