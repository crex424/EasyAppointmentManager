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
    public class TimeSlotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeSlotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeSlots
        public async Task<IActionResult> Index()
        {
            List<TimeSlotIndexViewModel> timeSlotData = await (from ts in _context.TimeSlot
                                                               join doctor in _context.Doctor
                                                                on ts.DoctorId equals doctor.DoctorId
                                                               orderby ts.TimeSlotDate
                                                               select new TimeSlotIndexViewModel
                                                               {
                                                                   TimeSlotId = ts.TimeSlotId,
                                                                   TimeSlotDate = ts.TimeSlotDate,
                                                                   StartTime = ts.StartTime,
                                                                   EndTime = ts.EndTime,
                                                                   DoctorName = doctor.FullName
                                                               }).ToListAsync();

            return View(timeSlotData);
        }

        // GET: TimeSlots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeSlot == null)
            {
                return NotFound();
            }

            var timeSlot = await _context.TimeSlot
                .FirstOrDefaultAsync(m => m.TimeSlotId == id);
            if (timeSlot == null)
            {
                return NotFound();
            }

            return View(timeSlot);
        }

        // GET: TimeSlots/Create
        public IActionResult Create()
        {
            TimeSlotCreateViewModel viewModel = new();

            // Get list of all doctors
            viewModel.AllAvailableDoctors = _context.Doctor.OrderBy(d => d.LastName).ToList();

            return View(viewModel);
        }

        // POST: TimeSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimeSlotCreateViewModel timeSlot)
        {
            if (ModelState.IsValid)
            {
                TimeSlot newTimeSlot = new()
                {
                    TimeSlotDate = timeSlot.TimeSlotDate,
                    StartTime = timeSlot.StartTime,
                    EndTime = timeSlot.EndTime,
                    TimeSlotStatus = timeSlot.TimeSlotStatus,
                    Doctor = new Doctor
                    {
                        DoctorId = timeSlot.ChosenDoctor
                    }
                };
                // Tell EF that we have not modified the existing Doctor
                _context.Entry(newTimeSlot.Doctor).State = EntityState.Unchanged;

                _context.Add(newTimeSlot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeSlot);
        }

        // GET: TimeSlots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TimeSlot == null)
            {
                return NotFound();
            }

            var timeSlot = await _context.TimeSlot.FindAsync(id);
            if (timeSlot == null)
            {
                return NotFound();
            }
            return View(timeSlot);
        }

        // POST: TimeSlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeSlotId,TimeSlotDate,StartTime,EndTime,TimeSlotStatus")] TimeSlot timeSlot)
        {
            if (id != timeSlot.TimeSlotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Tell EF that we have not modified the existing Doctor
                    _context.Entry(timeSlot.Doctor).State = EntityState.Unchanged;
                    _context.Update(timeSlot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSlotExists(timeSlot.TimeSlotId))
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
            return View(timeSlot);
        }

        // GET: TimeSlots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeSlot == null)
            {
                return NotFound();
            }

            var timeSlot = await _context.TimeSlot
                .FirstOrDefaultAsync(m => m.TimeSlotId == id);
            if (timeSlot == null)
            {
                return NotFound();
            }

            return View(timeSlot);
        }

        // POST: TimeSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TimeSlot == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TimeSlot'  is null.");
            }
            var timeSlot = await _context.TimeSlot.FindAsync(id);
            if (timeSlot != null)
            {
                _context.TimeSlot.Remove(timeSlot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSlotExists(int id)
        {
            return (_context.TimeSlot?.Any(e => e.TimeSlotId == id)).GetValueOrDefault();
        }
    }
}
