using EasyAppointmentManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyAppointmentManager.Models;

namespace EasyAppointmentManager.Controllers
{
    public class Doctor : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Doctor != null ?
                        View(await _context.Doctor.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Customer'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

    }
}
