using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyAppointmentManager.Data;
using EasyAppointmentManager.Models;
using Microsoft.CodeAnalysis;

namespace EasyAppointmentManager.Controllers
{
    public class ClinicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClinicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clinics
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clinic.Include(c => c.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Clinics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clinic == null)
            {
                return NotFound();
            }

            Clinic? clinic = await _context.Clinic
                                            .Include(c => c.Location)
                                            .FirstOrDefaultAsync(m => m.ClinicId == id);
            if (clinic == null)
            {
                return NotFound();
            }

            return View(clinic);
        }

        // GET: Clinics/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Set<Models.Location>(), "LocationID", "Address");
            return View();
        }

        // POST: Clinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClinicId,ClinicName,Code,Description,PhoneNumber,Email,LocationId")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinic);
                await _context.SaveChangesAsync();

                // Show success message on page
                ViewData["Message"] = $"{clinic.ClinicName} was added successfully!";

                return View();
            }
            ViewData["LocationId"] = new SelectList(_context.Set<Models.Location>(), "LocationID", "Address", clinic.LocationId);
            return View(clinic);
        }

        // GET: Clinics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clinic == null)
            {
                return NotFound();
            }

            Clinic? clinic = await _context.Clinic.FindAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Set<Models.Location>(), "LocationID", "Address", clinic.LocationId);
            return View(clinic);
        }

        // POST: Clinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClinicId,ClinicName,Code,Description,PhoneNumber,Email,LocationId")] Clinic clinic)
        {
            if (id != clinic.ClinicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(clinic);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{clinic.ClinicName} was updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Set<Models.Location>(), "LocationID", "Address", clinic.LocationId);
            return View(clinic);
        }

        // GET: Clinics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clinic == null)
            {
                return NotFound();
            }

            Clinic? clinic = await _context.Clinic
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.ClinicId == id);
            if (clinic == null)
            {
                return NotFound();
            }

            return View(clinic);
        }

        // POST: Clinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clinic == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Clinic'  is null.");
            }
            Clinic? clinic = await _context.Clinic.FindAsync(id);
            if (clinic != null)
            {
                _context.Clinic.Remove(clinic);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{clinic.ClinicName} was deleted successfully!";
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicExists(int id)
        {
          return (_context.Clinic?.Any(e => e.ClinicId == id)).GetValueOrDefault();
        }
    }
}
