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
    public class HandboeksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HandboeksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Handboeks
        public async Task<IActionResult> Index()
        {
              return _context.handboeken != null ? 
                          View(await _context.handboeken.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.handboeken'  is null.");
        }

        // GET: Handboeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.handboeken == null)
            {
                return NotFound();
            }

            var handboek = await _context.handboeken
                .FirstOrDefaultAsync(m => m.HandboekId == id);
            if (handboek == null)
            {
                return NotFound();
            }

            return View(handboek);
        }

        // GET: Handboeks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Handboeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HandboekId,Titel,KostPrijs,Uitgiftedatum,Afbeelding")] Handboek handboek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(handboek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(handboek);
        }

        // GET: Handboeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.handboeken == null)
            {
                return NotFound();
            }

            var handboek = await _context.handboeken.FindAsync(id);
            if (handboek == null)
            {
                return NotFound();
            }
            return View(handboek);
        }

        // POST: Handboeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HandboekId,Titel,KostPrijs,Uitgiftedatum,Afbeelding")] Handboek handboek)
        {
            if (id != handboek.HandboekId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(handboek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HandboekExists(handboek.HandboekId))
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
            return View(handboek);
        }

        // GET: Handboeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.handboeken == null)
            {
                return NotFound();
            }

            var handboek = await _context.handboeken
                .FirstOrDefaultAsync(m => m.HandboekId == id);
            if (handboek == null)
            {
                return NotFound();
            }

            return View(handboek);
        }

        // POST: Handboeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.handboeken == null)
            {
                return Problem("Entity set 'ApplicationDbContext.handboeken'  is null.");
            }
            var handboek = await _context.handboeken.FindAsync(id);
            if (handboek != null)
            {
                _context.handboeken.Remove(handboek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HandboekExists(int id)
        {
          return (_context.handboeken?.Any(e => e.HandboekId == id)).GetValueOrDefault();
        }
    }
}
