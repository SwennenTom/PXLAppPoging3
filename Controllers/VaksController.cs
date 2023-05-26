using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PXLApp3.Data;
using PXLApp.Models;

namespace PXLApp.Controllers
{
    public class VaksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VaksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vaks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.vakken.Include(v => v.Handboek);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vaks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.vakken == null)
            {
                return NotFound();
            }

            var vak = await _context.vakken
                .Include(v => v.Handboek)
                .FirstOrDefaultAsync(m => m.VakId == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // GET: Vaks/Create
        public IActionResult Create()
        {
            ViewData["HandboekId"] = new SelectList(_context.handboeken, "HandboekId", "Titel");
            return View();
        }

        // POST: Vaks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VakId,VakNaam,Studiepunten,HandboekId")] Vak vak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HandboekId"] = new SelectList(_context.handboeken, "HandboekId", "Titel", vak.HandboekId);
            return View(vak);
        }

        // GET: Vaks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.vakken == null)
            {
                return NotFound();
            }

            var vak = await _context.vakken.FindAsync(id);
            if (vak == null)
            {
                return NotFound();
            }
            ViewData["HandboekId"] = new SelectList(_context.handboeken, "HandboekId", "Titel", vak.HandboekId);
            return View(vak);
        }

        // POST: Vaks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VakId,VakNaam,Studiepunten,HandboekId")] Vak vak)
        {
            if (id != vak.VakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakExists(vak.VakId))
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
            ViewData["HandboekId"] = new SelectList(_context.handboeken, "HandboekId", "Titel", vak.HandboekId);
            return View(vak);
        }

        // GET: Vaks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.vakken == null)
            {
                return NotFound();
            }

            var vak = await _context.vakken
                .Include(v => v.Handboek)
                .FirstOrDefaultAsync(m => m.VakId == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // POST: Vaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.vakken == null)
            {
                return Problem("Entity set 'ApplicationDbContext.vakken'  is null.");
            }
            var vak = await _context.vakken.FindAsync(id);
            if (vak != null)
            {
                _context.vakken.Remove(vak);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VakExists(int id)
        {
          return (_context.vakken?.Any(e => e.VakId == id)).GetValueOrDefault();
        }
    }
}
