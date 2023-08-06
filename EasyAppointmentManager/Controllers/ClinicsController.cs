using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyAppointmentManager.Data;
using EasyAppointmentManager.Models;
using System.Numerics;
using Microsoft.AspNetCore.Authorization;

namespace EasyAppointmentManager.Controllers
{
    [Authorize(Roles="Admin")]
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
              return _context.Clinic != null ? 
                          View(await _context.Clinic.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Clinic'  is null.");
        }

        // GET: Clinics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clinic == null)
            {
                return NotFound();
            }

            var clinic = await _context.Clinic
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
            return View();
        }

        // POST: Clinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClinicId,ClinicName,ClinicCode,Description,PhoneNumber,Email,Address,City,ZipCode")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinic);
                await _context.SaveChangesAsync();

                // Show success message on page
                TempData["Message"] = $"{clinic.ClinicName} was added successfully!";

                return RedirectToAction(nameof(Index));
            }
            return View(clinic);
        }

        // GET: Clinics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clinic == null)
            {
                return NotFound();
            }

            var clinic = await _context.Clinic.FindAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClinicId,ClinicName,ClinicCode,Description,PhoneNumber,Email,Address,City,ZipCode")] Clinic clinic)
        {
            if (id != clinic.ClinicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinic);
                    await _context.SaveChangesAsync();

                    // Show success message on page
                    TempData["Message"] = $"{clinic.ClinicName} was updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicExists(clinic.ClinicId))
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
            return View(clinic);
        }

        // GET: Clinics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clinic == null)
            {
                return NotFound();
            }

            var clinic = await _context.Clinic
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
            var clinic = await _context.Clinic.FindAsync(id);
            if (clinic != null)
            {
                _context.Clinic.Remove(clinic);
            }
            
            await _context.SaveChangesAsync();

            // Show success message on page
            TempData["Message"] = $"{clinic.ClinicName} was deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicExists(int id)
        {
          return (_context.Clinic?.Any(e => e.ClinicId == id)).GetValueOrDefault();
        }
    }
}
