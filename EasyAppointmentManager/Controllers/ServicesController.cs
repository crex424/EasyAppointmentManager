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
using System.Data;

namespace EasyAppointmentManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {   
            List<ServiceIndexViewModel> serviceList = await (from s in _context.Service
                                                             join c in _context.Clinic 
                                                                on s.Clinic.ClinicId equals c.ClinicId
                                                             orderby s.ServiceName
                                                             select new ServiceIndexViewModel
                                                             {
                                                                 ServiceId = s.ServiceId,
                                                                 ServiceName = s.ServiceName,
                                                                 ServiceTime = s.ServiceTime,
                                                                 Fee = s.Fee,
                                                                 ClinicName = c.ClinicName
                                                             }).ToListAsync();
            return View(serviceList);
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            ServiceIndexViewModel? service = await (from s in _context.Service
                                                            join c in _context.Clinic
                                                            on s.Clinic.ClinicId equals c.ClinicId
                                                            where s.ServiceId == id
                                                            select new ServiceIndexViewModel
                                                            {
                                                                ServiceId = s.ServiceId,
                                                                ServiceName = s.ServiceName,
                                                                ServiceTime = s.ServiceTime,
                                                                Fee = s.Fee,
                                                                ClinicName = c.ClinicName
                                                            }).FirstOrDefaultAsync();
            // var serviceToUpdate = await _context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ServiceCreateViewModel viewModel = new();
            viewModel.Clinics = _context.Clinic.OrderBy(i => i.ClinicName).ToList();
            return View(viewModel);
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceCreateViewModel service)
        {
            if (ModelState.IsValid)
            {
                Service newService = new()
                {
                    ServiceName = service.ServiceName,
                    ServiceTime = service.ServiceTime,
                    Fee = service.Fee,
                    Clinic = new Clinic()
                    {
                        ClinicId = service.ChosenClinic
                    }
                };
                // Tell EF that we have not modified the existing Clinics
                _context.Entry(newService.Clinic).State = EntityState.Unchanged;

                _context.Add(newService);
                await _context.SaveChangesAsync();

                // Show success message on page
                TempData["Message"] = $"{service.ServiceName} was added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            // var serviceToUpdate = await _context.Service.FindAsync(id);
            ServiceEditViewModel? serviceToUpdate = await (from s in _context.Service
                                                             join c in _context.Clinic
                                                             on s.Clinic.ClinicId equals c.ClinicId
                                                             where s.ServiceId == id
                                                             select new ServiceEditViewModel
                                                             {
                                                                 ServiceId = s.ServiceId,
                                                                 ServiceName = s.ServiceName,
                                                                 ServiceTime = s.ServiceTime,
                                                                 Fee = s.Fee,
                                                                 ClinicId = c.ClinicId
                                                             }).FirstOrDefaultAsync();


            serviceToUpdate.Clinics = _context.Clinic.OrderBy(i => i.ClinicName).ToList();

            if (serviceToUpdate == null)
            {
                return NotFound();
            }
            return View(serviceToUpdate);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceEditViewModel serviceToUpdate)
        {
            if (id != serviceToUpdate.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Service? existingService = await _context.Service
                                                            .Include(s => s.Clinic) // Include the Clinic property
                                                            .FirstOrDefaultAsync(s => s.ServiceId == id);
                    // not working: Service? existingService = await _context.Service.FindAsync(id);
                    /* not working:
                    ServiceEditViewModel? existingService = await (from s in _context.Service
                                                             join c in _context.Clinic
                                                             on s.Clinic.ClinicId equals c.ClinicId
                                                             where s.ServiceId == id
                                                             select new ServiceEditViewModel
                                                             {
                                                                 ServiceId = s.ServiceId,
                                                                 ServiceName = s.ServiceName,
                                                                 ServiceTime = s.ServiceTime,
                                                                 Fee = s.Fee,
                                                                 ClinicId = c.ClinicId
                                                             }).FirstOrDefaultAsync();
                    */
                    if (existingService == null)
                    {
                        return NotFound();
                    }

                    // Update the existingService properties
                    existingService.ServiceName = serviceToUpdate.ServiceName;
                    existingService.ServiceTime = serviceToUpdate.ServiceTime;
                    existingService.Fee = serviceToUpdate.Fee;

                    // Update the clinic if it has changed
                    if (existingService.Clinic.ClinicId != serviceToUpdate.ClinicId)
                    {
                        var clinic = await _context.Clinic.FindAsync(serviceToUpdate.ClinicId);
                        if (clinic == null)
                        {
                            return NotFound();
                        }

                        //existingService.Clinic.ClinicId = clinic.ClinicId;
                        existingService.Clinic = clinic;
                    }

                    _context.Update(existingService);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = $"{existingService.ServiceName} was updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(serviceToUpdate.ServiceId))
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
            return View(serviceToUpdate);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }
            ServiceIndexViewModel? service = await (from s in _context.Service
                                                    join c in _context.Clinic
                                                    on s.Clinic.ClinicId equals c.ClinicId
                                                    where s.ServiceId == id
                                                    select new ServiceIndexViewModel
                                                    {
                                                        ServiceId = s.ServiceId,
                                                        ServiceName = s.ServiceName,
                                                        ServiceTime = s.ServiceTime,
                                                        Fee = s.Fee,
                                                        ClinicName = c.ClinicName
                                                    }).FirstOrDefaultAsync();
            // var serviceToUpdate = await _context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Service == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Service'  is null.");
            }
            var service = await _context.Service.FindAsync(id);
            if (service != null)
            {
                _context.Service.Remove(service);
                TempData["Message"] = $"{service.ServiceName} was deleted successfully!";
            }
            TempData["Message"] = $"This service was already deleted!";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
          return (_context.Service?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
