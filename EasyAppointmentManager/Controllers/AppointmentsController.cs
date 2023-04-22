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
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
              return _context.Appointment != null ? 
                          View(await _context.Appointment.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Appointment'  is null.");
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointment == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            AppointmentCreateViewModel viewModel = new();
            viewModel.AllAvailableCustomers = _context.Customer.OrderBy(i => i.LastName).ToList();
            viewModel.AllAvailableDoctors = _context.Doctor.OrderBy(i => i.LastName).ToList();
            viewModel.AllAvailableClinics = _context.Clinic.OrderBy(i => i.ClinicName).ToList();
            viewModel.AllAvailableServices = _context.Service.OrderBy(i => i.ServiceName).ToList();
            return View(viewModel);
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentCreateViewModel appointment)
        {
            if (ModelState.IsValid)
            {
                Appointment newAppointment = new()
                {
                    Date = appointment.Date,
                    Timeslot = appointment.Timeslot,
                    
                    Customer = new Customer()
                    {
                        CustomerId = appointment.ChosenCustomer.CustomerId
                    },
                    
                    Clinic = new Clinic()
                    {
                        ClinicId = appointment.ChosenClinic.ClinicId
                    },

                    Service = new Service()
                    {
                        ServiceId = appointment.ChosenService.ServiceId
                    },

                    Doctor = new Doctor()
                    {
                        DoctorId = appointment.ChosenDoctor.DoctorId
                    }
                };

                _context.Add(newAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            appointment.AllAvailableCustomers = _context.Customer.OrderBy(i => i.LastName).ToList();
            appointment.AllAvailableDoctors = _context.Doctor.OrderBy(i => i.LastName).ToList();
            appointment.AllAvailableClinics = _context.Clinic.OrderBy(i => i.ClinicName).ToList();
            appointment.AllAvailableServices = _context.Service.OrderBy(i => i.ServiceName).ToList();
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointment == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,Date,Timeslot")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointment == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Appointment'  is null.");
            }
            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointment.Remove(appointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
          return (_context.Appointment?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
    }
}
