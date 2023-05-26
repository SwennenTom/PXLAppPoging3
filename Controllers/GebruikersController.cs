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
    public class GebruikersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GebruikersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gebruikers
        public async Task<IActionResult> Index()
        {
              return _context.gebruikers != null ? 
                          View(await _context.gebruikers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.gebruikers'  is null.");
        }

        // GET: Gebruikers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.gebruikers == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.gebruikers
                .FirstOrDefaultAsync(m => m.GebruikerId == id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            return View(gebruiker);
        }

        // GET: Gebruikers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gebruikers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GebruikerId,Naam,Voornaam,Email")] Gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gebruiker);
        }

        // GET: Gebruikers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.gebruikers == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.gebruikers.FindAsync(id);
            if (gebruiker == null)
            {
                return NotFound();
            }
            return View(gebruiker);
        }

        // POST: Gebruikers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GebruikerId,Naam,Voornaam,Email")] Gebruiker gebruiker)
        {
            if (id != gebruiker.GebruikerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gebruiker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GebruikerExists(gebruiker.GebruikerId))
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
            return View(gebruiker);
        }

        // GET: Gebruikers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.gebruikers == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.gebruikers
                .FirstOrDefaultAsync(m => m.GebruikerId == id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            return View(gebruiker);
        }

        // POST: Gebruikers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.gebruikers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.gebruikers'  is null.");
            }
            var gebruiker = await _context.gebruikers.FindAsync(id);
            if (gebruiker != null)
            {
                _context.gebruikers.Remove(gebruiker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GebruikerExists(int id)
        {
          return (_context.gebruikers?.Any(e => e.GebruikerId == id)).GetValueOrDefault();
        }
    }
}
