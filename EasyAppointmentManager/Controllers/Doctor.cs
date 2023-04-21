using EasyAppointmentManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyAppointmentManager.Models;

namespace EasyAppointmentManager.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get Doctors
        /// </summary>
        /// <returns>Docotrs</returns>
        public async Task<IActionResult> Index()
        {
            return _context.Doctor != null ?
                        View(await _context.Doctor.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Customer'  is null.");
        }
        /// <summary>
        /// Gets details of a Doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The details of a Doctor</returns>
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

        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a Doctor object
        /// </summary>
        /// <param name="doctor">The doctor to be created</param>
        /// <returns>The new Doctor object</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorID,FirstName,MiddleName,LastName,DateOfBirth" +
                                                      ",Gender,SpecializationID,Email,PhoneNumber,PlaceOfWork")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();

                // Show success message on page
                ViewData["Message"] = $"{doctor.LastName}, {doctor.FirstName} was added successfully!";

                return View();
            }
            return View(doctor);
        }

    }
}
