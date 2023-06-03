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
    public class CustomerAppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerAppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerAppointments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CustomerAppointment.Include(c => c.TimeSlot);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CustomerAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerAppointment == null)
            {
                return NotFound();
            }

            var customerAppointment = await _context.CustomerAppointment
                .Include(c => c.TimeSlot)
                .FirstOrDefaultAsync(m => m.CustomerAppointmentId == id);
            if (customerAppointment == null)
            {
                return NotFound();
            }

            return View(customerAppointment);
        }

        // GET: CustomerAppointments/Create
        public IActionResult Create()
        {
            ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "TimeSlotId", "TimeSlotId");
            return View();
        }

        // POST: CustomerAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerAppointmentId,TimeSlotId,CustomerAppointmentStatus")] CustomerAppointment customerAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "TimeSlotId", "TimeSlotId", customerAppointment.TimeSlotId);
            return View(customerAppointment);
        }

        // GET: CustomerAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerAppointment == null)
            {
                return NotFound();
            }

            var customerAppointment = await _context.CustomerAppointment.FindAsync(id);
            if (customerAppointment == null)
            {
                return NotFound();
            }
            ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "TimeSlotId", "TimeSlotId", customerAppointment.TimeSlotId);
            return View(customerAppointment);
        }

        // POST: CustomerAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerAppointmentId,TimeSlotId,CustomerAppointmentStatus")] CustomerAppointment customerAppointment)
        {
            if (id != customerAppointment.CustomerAppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerAppointmentExists(customerAppointment.CustomerAppointmentId))
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
            ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "TimeSlotId", "TimeSlotId", customerAppointment.TimeSlotId);
            return View(customerAppointment);
        }

        // GET: CustomerAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomerAppointment == null)
            {
                return NotFound();
            }

            var customerAppointment = await _context.CustomerAppointment
                .Include(c => c.TimeSlot)
                .FirstOrDefaultAsync(m => m.CustomerAppointmentId == id);
            if (customerAppointment == null)
            {
                return NotFound();
            }

            return View(customerAppointment);
        }

        // POST: CustomerAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomerAppointment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CustomerAppointment'  is null.");
            }
            var customerAppointment = await _context.CustomerAppointment.FindAsync(id);
            if (customerAppointment != null)
            {
                _context.CustomerAppointment.Remove(customerAppointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerAppointmentExists(int id)
        {
          return (_context.CustomerAppointment?.Any(e => e.CustomerAppointmentId == id)).GetValueOrDefault();
        }
    }
}
