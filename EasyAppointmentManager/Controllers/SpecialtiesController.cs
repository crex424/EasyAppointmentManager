using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyAppointmentManager.Data;
using EasyAppointmentManager.Models;

namespace EasyAppointmentManager.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialtiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Specialty
        public async Task<IActionResult> Index()
        {
              return _context.Specialty != null ? 
                          View(await _context.Specialty.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Specialty' is null.");
        }

        // GET: Specialty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Specialty == null)
            {
                return NotFound();
            }

            Specialty? specialty = await _context.Specialty.FirstOrDefaultAsync(m => m.SpecialtyId == id);
            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        // GET: Specialty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialtyId,Name,Code,Description")] Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialty);
                await _context.SaveChangesAsync();

                // Show success message on page
                ViewData["Message"] = $"{specialty.Name} was added successfully!";

                return View();
            }
            return View(specialty);
        }

        // GET: Specialty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Specialty == null)
            {
                return NotFound();
            }

            Specialty? specialty = await _context.Specialty.FindAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        // POST: Specialty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialtyId,Name,Code,Description")] Specialty specialty)
        {
            if (id != specialty.SpecialtyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(specialty);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{specialty.Name} was updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(specialty);
        }

        // GET: Specialty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Specialty == null)
            {
                return NotFound();
            }

            Specialty? specialty = await _context.Specialty.FirstOrDefaultAsync(m => m.SpecialtyId == id);
            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        // POST: Specialty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Specialty == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Specialty'  is null.");
            }

            Specialty? specialty = await _context.Specialty.FindAsync(id);
            if (specialty != null)
            {
                _context.Specialty.Remove(specialty);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{specialty.Name} was deleted successfully!";
            }

            TempData["Message"] = $"This specialty was already deleted!";
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialtyExists(int id)
        {
          return (_context.Specialty?.Any(e => e.SpecialtyId == id)).GetValueOrDefault();
        }
    }
}
