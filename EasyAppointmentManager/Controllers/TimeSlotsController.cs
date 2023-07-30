using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyAppointmentManager.Data;
using EasyAppointmentManager.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace EasyAppointmentManager.Controllers
{
    [Authorize(Roles = "Admin")]
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
            List<TimeSlotIndexViewModel> timeSlotList = await (from ts in _context.TimeSlot
                                                               join doctor in _context.Doctor
                                                                on ts.DoctorId equals doctor.DoctorId
                                                               orderby ts.TimeSlotDate, ts.Doctor.LastName
                                                               select new TimeSlotIndexViewModel
                                                               {
                                                                   TimeSlotId = ts.TimeSlotId,
                                                                   TimeSlotDate = ts.TimeSlotDate,                                                                   
                                                                   StartTime = ts.StartTime,
                                                                   EndTime = ts.EndTime,
                                                                   TimeSlotStatus = ts.TimeSlotStatus,
                                                                   DoctorName = doctor.FullName
                                                               }).ToListAsync();

            return View(timeSlotList);
        }

        // GET: TimeSlots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeSlot == null)
            {
                return NotFound();
            }

            TimeSlotIndexViewModel? timeSlot = await (from ts in _context.TimeSlot
                                                      join doctor in _context.Doctor
                                                      on ts.DoctorId equals doctor.DoctorId
                                                      where ts.TimeSlotId == id
                                                      select new TimeSlotIndexViewModel
                                                      {
                                                          TimeSlotId = ts.TimeSlotId,
                                                          TimeSlotDate = ts.TimeSlotDate,
                                                          StartTime = ts.StartTime,
                                                          EndTime = ts.EndTime,
                                                          TimeSlotStatus = ts.TimeSlotStatus,
                                                          DoctorName = doctor.FullName
                                                      }).FirstOrDefaultAsync();

            //var timeSlotToUpdate = await _context.TimeSlot.FirstOrDefaultAsync(m => m.TimeSlotId == id);

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
            viewModel.Doctors = _context.Doctor.OrderBy(d => d.LastName).ToList();

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

            // var timeSlotToUpdate = await _context.TimeSlot.FindAsync(id);

            TimeSlotIndexViewModel? timeSlot = await (from ts in _context.TimeSlot
                                                      join doctor in _context.Doctor
                                                      on ts.DoctorId equals doctor.DoctorId
                                                      where ts.TimeSlotId == id
                                                      select new TimeSlotIndexViewModel
                                                      {
                                                          TimeSlotId = ts.TimeSlotId,
                                                          TimeSlotDate = ts.TimeSlotDate,
                                                          StartTime = ts.StartTime,
                                                          EndTime = ts.EndTime,
                                                          TimeSlotStatus = ts.TimeSlotStatus,
                                                          DoctorName = ts.Doctor.FullName
                                                      }).FirstOrDefaultAsync();

            
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
        public async Task<IActionResult> Edit(int id, TimeSlotIndexViewModel timeSlotToUpdate)
        {
            if (id != timeSlotToUpdate.TimeSlotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TimeSlot? existingTimeSlot = await _context.TimeSlot
                                                                // .Include(ts => ts.Doctor) // Include the DoctorId
                                                                .FirstOrDefaultAsync(ts => ts.TimeSlotId == id);
                    if (existingTimeSlot == null)
                    {
                        return NotFound();
                    }

                    // Update the existingTimeSlot properties
                    /*
                    existingTimeSlot.TimeSlotId = timeSlotToUpdate.TimeSlotId;
                    existingTimeSlot.TimeSlotDate = timeSlotToUpdate.TimeSlotDate;
                    existingTimeSlot.StartTime = timeSlotToUpdate.StartTime;
                    existingTimeSlot.EndTime = timeSlotToUpdate.EndTime;
                    existingTimeSlot.DoctorId = timeSlotToUpdate.DoctorId;
                    */
                    existingTimeSlot.TimeSlotStatus = timeSlotToUpdate.TimeSlotStatus;
                    

                    _context.Update(existingTimeSlot);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = $"TimeSlot was successfully updated to {existingTimeSlot.TimeSlotStatus}!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSlotExists(timeSlotToUpdate.TimeSlotId))
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
            else
            {
                // There are validation errors, so you can inspect them
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // You can log or display the error message
                    var errorMessage = error.ErrorMessage;
                    // Handle the error as needed
                }
            }
            return View(timeSlotToUpdate);
        }

        // GET: TimeSlots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeSlot == null)
            {
                return NotFound();
            }


            //var timeSlotToUpdate = await _context.TimeSlot.FirstOrDefaultAsync(m => m.TimeSlotId == id);

            TimeSlotIndexViewModel? timeSlot = await (from ts in _context.TimeSlot
                                                      join doctor in _context.Doctor
                                                      on ts.DoctorId equals doctor.DoctorId
                                                      where ts.TimeSlotId == id
                                                      select new TimeSlotIndexViewModel
                                                      {
                                                          TimeSlotId = ts.TimeSlotId,
                                                          TimeSlotDate = ts.TimeSlotDate,
                                                          StartTime = ts.StartTime,
                                                          EndTime = ts.EndTime,
                                                          TimeSlotStatus = ts.TimeSlotStatus,
                                                          DoctorName = doctor.FullName
                                                      }).FirstOrDefaultAsync();

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
