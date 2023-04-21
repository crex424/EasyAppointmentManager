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
                        Problem("Entity set 'ApplicationDbContext.Doctor'  is null.");
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
        /// <summary>
        /// Takes user to create page for Doctor Object
        /// </summary>
        /// <returns>User to Create page</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a Doctor object
        /// </summary>
        /// <param name="doctor">The doctor to be created</param>
        /// <returns>The new Doctor object to the Doctor index page</returns>
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
        /// <returns>a edited Doctor to the Doctor index paget</returns>
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
        /// If not, return a NotFound error. 
        /// If the doctor exists allow user to edit information.
        /// </summary>
        /// <param name="id">Doctor's unique identifier</param>
        /// <param name="doctor">The Doctor Object</param>
        /// <returns> a edited Doctor to the Doctor index page</returns>
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

        /// <summary>
        /// Deletes a selected Doctor Object if it exists.
        /// If Doctor does not exist return a NotFound error.
        /// </summary>
        /// <param name="id">Doctor's unique identifier</param>
        /// <returns>Returns to Doctor index page</returns>
        public async Task<IActionResult> Delete(int? id)
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
        /// <summary>
        /// Deletes a selected Doctor Object if it exists.
        /// If Doctor does not exist return a error.
        /// </summary>
        /// <param name="id">Doctor's unique identifier</param>
        /// <returns>Returns user to index page with success message</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Doctor' is null.");
            }

            Doctor? doctor = await _context.Doctor.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctor.Remove(doctor);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{doctor.LastName}, {doctor.FirstName} was deleted successfully!";
            }

            TempData["Message"] = $"This doctor was already deleted!";
            return RedirectToAction(nameof(Index));
        }

    }
}
