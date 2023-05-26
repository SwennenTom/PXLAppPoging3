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
    public class InschrijvingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InschrijvingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inschrijvings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.inschrijvingen
                .Include(i => i.AcademieJaar)
                .Include(i => i.Student).ThenInclude(l => l.Gebruiker)
                .Include(i => i.VakLector).ThenInclude(v => v.Vak)
                .Include(j => j.VakLector).ThenInclude(u => u.Lector);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inschrijvings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.inschrijvingen == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.inschrijvingen
                .Include(i => i.AcademieJaar)
                .Include(i => i.Student).ThenInclude(l => l.Gebruiker)
                .Include(i => i.VakLector).ThenInclude(v => v.Vak)
                .Include(j => j.VakLector).ThenInclude(u => u.Lector)
                .FirstOrDefaultAsync(m => m.InschrijvingId == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // GET: Inschrijvings/Create
        public IActionResult Create()
        {
            ViewData["AcademieJaarId"] = new SelectList(_context.academieJaren, "AcademieJaarId", "StartDatum");
            ViewData["StudentId"] = new SelectList(_context.students.Include(l => l.Gebruiker), "StudentId", "Gebruiker.Voornaam");
            ViewData["VakLectorId"] = new SelectList(_context.vakLectoren.Include(k => k.Vak), "VakLectorId", "Vak.VakNaam");
            return View();
        }

        // POST: Inschrijvings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InschrijvingId,StudentId,VakLectorId,AcademieJaarId")] Inschrijving inschrijving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inschrijving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademieJaarId"] = new SelectList(_context.academieJaren, "AcademieJaarId", "AcademieJaarId", inschrijving.AcademieJaarId);
            ViewData["StudentId"] = new SelectList(_context.students, "StudentId", "StudentId", inschrijving.StudentId);
            ViewData["VakLectorId"] = new SelectList(_context.vakLectoren, "VakLectorId", "VakLectorId", inschrijving.VakLectorId);
            return View(inschrijving);
        }

        // GET: Inschrijvings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.inschrijvingen == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.inschrijvingen.FindAsync(id);
            if (inschrijving == null)
            {
                return NotFound();
            }
            ViewData["AcademieJaarId"] = new SelectList(_context.academieJaren, "AcademieJaarId", "StartDatum", inschrijving.AcademieJaarId);
            ViewData["StudentId"] = new SelectList(_context.students.Include(i => i.Gebruiker), "StudentId", "Gebruiker.Voornaam", inschrijving.StudentId);
            ViewData["VakLectorId"] = new SelectList(_context.vakLectoren.Include(i => i.Vak), "VakLectorId", "Vak.VakNaam", inschrijving.VakLectorId);
            return View(inschrijving);
        }

        // POST: Inschrijvings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InschrijvingId,StudentId,VakLectorId,AcademieJaarId")] Inschrijving inschrijving)
        {
            if (id != inschrijving.InschrijvingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inschrijving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InschrijvingExists(inschrijving.InschrijvingId))
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
            ViewData["AcademieJaarId"] = new SelectList(_context.academieJaren, "AcademieJaarId", "AcademieJaarId", inschrijving.AcademieJaarId);
            ViewData["StudentId"] = new SelectList(_context.students, "StudentId", "StudentId", inschrijving.StudentId);
            ViewData["VakLectorId"] = new SelectList(_context.vakLectoren, "VakLectorId", "VakLectorId", inschrijving.VakLectorId);
            return View(inschrijving);
        }

        // GET: Inschrijvings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.inschrijvingen == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.inschrijvingen
                .Include(i => i.AcademieJaar)
                .Include(i => i.Student)
                .Include(i => i.VakLector)
                .FirstOrDefaultAsync(m => m.InschrijvingId == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // POST: Inschrijvings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.inschrijvingen == null)
            {
                return Problem("Entity set 'ApplicationDbContext.inschrijvingen'  is null.");
            }
            var inschrijving = await _context.inschrijvingen.FindAsync(id);
            if (inschrijving != null)
            {
                _context.inschrijvingen.Remove(inschrijving);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InschrijvingExists(int id)
        {
          return (_context.inschrijvingen?.Any(e => e.InschrijvingId == id)).GetValueOrDefault();
        }
    }
}
