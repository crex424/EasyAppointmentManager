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

        /// <summary>
        /// Checks whether a selected Doctor exists.
        /// If not, return a NotFound page. 
        /// If the doctor exists return to doctor page
        /// </summary>
        /// <param name="id">The Doctor's unique identifier</param>
        /// <returns>A edited Doctor Object</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            Doctor? doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        /// <summary>
        /// Checks whether a selected Doctor exists.
        /// If not, return a NotFound page. 
        /// If the doctor exists allow user to edit information
        /// </summary>
        /// <param name="id">Doctor's unique identifier</param>
        /// <param name="doctor">The Doctor Object</param>
        /// <returns>A edited Doctor Object</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorID,FirstName,MiddleName,LastName,DateOfBirth" +
                                                      ",Gender,SpecializationID,Email,PhoneNumber,PlaceOfWork")] Doctor doctor)
        {
            if (id != doctor.DoctorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(doctor);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{doctor.LastName}, {doctor.FirstName} was updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

    }
}
