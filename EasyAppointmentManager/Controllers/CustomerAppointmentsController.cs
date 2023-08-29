using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyAppointmentManager.Data;
using EasyAppointmentManager.Models;
using Microsoft.CodeAnalysis.VisualBasic;
using System.Numerics;

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


        [HttpPost]
        public ActionResult Submit(FormCollection formcollection)
        {
            TempData["Message"] = "Doctor Full Name: " + formcollection["FullName"];
            TempData["Message"] += "\\nDoctor Id: " + formcollection["DoctorId"]; ;
            return RedirectToAction("Create");
        }

        // GET: CustomerAppointments/Create
        public async Task<IActionResult> Create()
        {
            CustomerAppointmentCreateViewModel viewModel = new();

            // Get list of all customers
            viewModel.AllAvailableCustomers = await _context.Customer.OrderBy(i => i.LastName).ToListAsync();

            // Get list of all doctors
            viewModel.AllAvailableDoctors = await _context.Doctor.OrderBy(i => i.LastName).ToListAsync();
            /*
            viewModel.AllAvailableDoctors = await (from ts in _context.TimeSlot
                                       join doctor in _context.Doctor on ts.DoctorId equals doctor.DoctorId
                                       orderby doctor
                                       select doctor).Distinct().ToListAsync();
            */
            /*
            viewModel.AvailableTimeSlotsByDoctorId = await (from timeSlot in _context.TimeSlot
                                                    where timeSlot.DoctorId == viewModel.ChosenDoctorId
                                                    orderby timeSlot.TimeSlotDate
                                                    select timeSlot).ToListAsync();
            
            if (viewModel.ChosenDoctorId > 0)
            {
                viewModel.AvailableTimeSlotsByDoctorId = await _context.TimeSlot
                                                        .Where(ts => ts.DoctorId == viewModel.ChosenDoctorId && ts.TimeSlotStatus == TimeslotStatus.Available)
                                                        .OrderBy(ts => ts.TimeSlotDate)
                                                        .ToListAsync();
            }
            */

            //viewModel.AvailableTimeSlotsByDoctorId = _context.TimeSlot
            //.Where(t => t.DoctorId == viewModel.ChosenDoctorId)
            //                                               .OrderBy(t => t.TimeSlotDate).ToList();

            // ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "TimeSlotId", "TimeSlotId");
            return View(viewModel);
        }

        public async Task<List<TimeSlot>> GetAvailableTimeSlotsByDoctorId(int DoctorId)
        {
            CustomerAppointmentCreateViewModel viewModel = new();
            viewModel.AvailableTimeSlotsByDoctorId = await _context.TimeSlot
                                                        .Where(ts => ts.DoctorId == DoctorId && ts.TimeSlotStatus == TimeslotStatus.Available)
                                                        .OrderBy(ts => ts.TimeSlotDate)
                                                        .ToListAsync();

            return viewModel.AvailableTimeSlotsByDoctorId;
        }

        // POST: CustomerAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerAppointmentCreateViewModel customerAppointment)
        {
            if (ModelState.IsValid)
            {
                CustomerAppointment? newCustomerAppointment = new()
                {
                    TimeSlot = new TimeSlot
                    {
                        TimeSlotId = (int)customerAppointment.ChosenTimeSlotId
                    },
                    CustomerAppointmentStatus = CustomerAppointmentStatus.Booked,
                    Customer = new Customer()
                    {
                        CustomerId = (int)customerAppointment.ChosenCustomerId
                    }
                };

                // Tell EF that we have not modified the existing Customers
                _context.Entry(newCustomerAppointment.Customer).State = EntityState.Unchanged;


                // Needs to change the TimeslotStatus of the chosen TimeSlot from Available to Booked

                // Get chosen time slot  
                TimeSlot? timeSlot = _context.TimeSlot.Find(customerAppointment.ChosenTimeSlotId);

                // Update status of the chosen TimeSlot
                timeSlot.TimeSlotStatus = TimeslotStatus.Booked;

                // Tell EF that we have modified the existing TimeSlots
                _context.Entry(newCustomerAppointment.TimeSlot).State = EntityState.Modified; 
                
                // _context.Entry(newCustomerAppointment.TimeSlot).State = EntityState.Unchanged;

                _context.Add(newCustomerAppointment);
                await _context.SaveChangesAsync();

                // Show success message on page
                TempData["Message"] = $"Appointment for {newCustomerAppointment.Customer.FullName} " +
                                      $"with Dr.{newCustomerAppointment.TimeSlot.Doctor.FullName} " +
                                      $"on {newCustomerAppointment.TimeSlot.TimeSlotDate} " +
                                      $"from {newCustomerAppointment.TimeSlot.StartTime} " +
                                      $"to {newCustomerAppointment.TimeSlot.EndTime} " +
                                      $"was added successfully!";

                return RedirectToAction(nameof(Index));
            }
            
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
