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
    public class AcademieJaarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademieJaarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcademieJaars
        public async Task<IActionResult> Index()
        {
              return _context.academieJaren != null ? 
                          View(await _context.academieJaren.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.academieJaren'  is null.");
        }

        // GET: AcademieJaars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.academieJaren == null)
            {
                return NotFound();
            }

            var academieJaar = await _context.academieJaren
                .FirstOrDefaultAsync(m => m.AcademieJaarId == id);
            if (academieJaar == null)
            {
                return NotFound();
            }

            return View(academieJaar);
        }

        // GET: AcademieJaars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademieJaars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcademieJaarId,StartDatum")] AcademieJaar academieJaar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academieJaar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academieJaar);
        }

        // GET: AcademieJaars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.academieJaren == null)
            {
                return NotFound();
            }

            var academieJaar = await _context.academieJaren.FindAsync(id);
            if (academieJaar == null)
            {
                return NotFound();
            }
            return View(academieJaar);
        }

        // POST: AcademieJaars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcademieJaarId,StartDatum")] AcademieJaar academieJaar)
        {
            if (id != academieJaar.AcademieJaarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academieJaar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademieJaarExists(academieJaar.AcademieJaarId))
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
            return View(academieJaar);
        }

        // GET: AcademieJaars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.academieJaren == null)
            {
                return NotFound();
            }

            var academieJaar = await _context.academieJaren
                .FirstOrDefaultAsync(m => m.AcademieJaarId == id);
            if (academieJaar == null)
            {
                return NotFound();
            }

            return View(academieJaar);
        }

        // POST: AcademieJaars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.academieJaren == null)
            {
                return Problem("Entity set 'ApplicationDbContext.academieJaren'  is null.");
            }
            var academieJaar = await _context.academieJaren.FindAsync(id);
            if (academieJaar != null)
            {
                _context.academieJaren.Remove(academieJaar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademieJaarExists(int id)
        {
          return (_context.academieJaren?.Any(e => e.AcademieJaarId == id)).GetValueOrDefault();
        }
    }
}
