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

namespace EasyAppointmentManager.Controllers
{
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
            // var service = await _context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);
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
                ViewData["Message"] = $"{service.ServiceName} was added successfully!";
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

            ServiceIndexViewModel? serviceToUpdate = await (from s in _context.Service
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
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,Fee,ServiceName,ServiceTime")] Service service)
        {
            if (id != service.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceId))
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
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .FirstOrDefaultAsync(m => m.ServiceId == id);
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
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
          return (_context.Service?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
