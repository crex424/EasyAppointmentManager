using EasyAppointmentManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyAppointmentManager.Models;
using System.Numerics;

namespace EasyAppointmentManager.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get Doctors
        /// </summary>
        /// <returns>Docotrs</returns>
        public async Task<IActionResult> Index()
        {
            // Doctor information with their specialty and clinic
            List<DoctorIndexViewModel> doctorData = await (from d in _context.Doctor
                             join s in _context.Specialty
                                on d.Specialty.SpecialtyId equals s.SpecialtyId
                             join c in _context.Clinic
                                on d.Clinic.ClinicId equals c.ClinicId
                             orderby d.FirstName
                             select new DoctorIndexViewModel
                             {
                                 DoctorId = d.DoctorId,
                                 SpecialtyId = s.SpecialtyId,
                                 ClinicId = c.ClinicId,
                                 SpecialtyName = s.Name,
                                 ClinicName = c.ClinicName,
                                 FirstName = d.FirstName,
                                 MiddleName = d.MiddleName,
                                 LastName = d.LastName,
                                 //DateOfBirth = c.DateOfBirth,
                                 Gender = d.Gender
                                 //Email = c.Email,
                                 //PhoneNumber = c.PhoneNumber
                             }).ToListAsync();

            return View(doctorData);
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

            DoctorIndexViewModel? doctorData = await (from d in _context.Doctor
                                                      join s in _context.Specialty
                                                        on d.Specialty.SpecialtyId equals s.SpecialtyId
                                                      join c in _context.Clinic
                                                        on d.Clinic.ClinicId equals c.ClinicId
                                                      where d.DoctorId == id
                                                      orderby d.FirstName
                                                      select new DoctorIndexViewModel
                                                      {
                                                          DoctorId = d.DoctorId,
                                                          SpecialtyId = s.SpecialtyId,
                                                          ClinicId = c.ClinicId,
                                                          SpecialtyName = s.Name,
                                                          ClinicName = c.ClinicName,
                                                          FirstName = d.FirstName,
                                                          MiddleName = d.MiddleName,
                                                          LastName = d.LastName,
                                                          DateOfBirth = d.DateOfBirth,
                                                          Gender = d.Gender,
                                                          Email = d.Email,
                                                          PhoneNumber = d.PhoneNumber
                                                      }).FirstOrDefaultAsync();
            if (doctorData == null)
            {
                return NotFound();
            }

            return View(doctorData);
        }
        /// <summary>
        /// Takes user to create page for Doctor Object
        /// </summary>
        /// <returns>User to Create page</returns>
        public IActionResult Create()
        {
            DoctorCreateViewModel viewModel = new();
            viewModel.Specialties = _context.Specialty.OrderBy(i => i.Name).ToList();
            viewModel.Clinics = _context.Clinic.OrderBy(i => i.ClinicName).ToList();
            return View(viewModel);
        }

        /// <summary>
        /// Creates a Doctor object
        /// </summary>
        /// <param name="doctor">The doctor to be created</param>
        /// <returns>The new Doctor object to the Doctor index page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorCreateViewModel doctor)
        {
            if (ModelState.IsValid)
            {
                // Converting new Doctor data from DoctorCreateViewModel to Doctor
                Doctor newDoctor = new()
                {
                    FirstName = doctor.FirstName,
                    MiddleName = doctor.MiddleName,
                    LastName = doctor.LastName,
                    DateOfBirth = doctor.DateOfBirth,
                    Gender = doctor.Gender,
                    Specialty = new Specialty()
                    {
                        SpecialtyId = doctor.ChosenSpecialty
                    },
                    Email = doctor.Email,
                    PhoneNumber = doctor.PhoneNumber,
                    Clinic = new Clinic()
                    {
                        ClinicId = doctor.ChosenClinic
                    }

                };

                // Tell EF that we have not modified the existing Specialties
                _context.Entry(newDoctor.Specialty).State = EntityState.Unchanged;
                // Tell EF that we have not modified the existing Clinics
                _context.Entry(newDoctor.Clinic).State = EntityState.Unchanged;

                _context.Add(newDoctor);
                await _context.SaveChangesAsync();

                // Show success message on page
                ViewData["Message"] = $"{doctor.LastName}, {doctor.FirstName} was added successfully!";

                return RedirectToAction(nameof(Index));
            }
            doctor.Specialties = _context.Specialty.OrderBy(i => i.Name).ToList();
            doctor.Clinics = _context.Clinic.OrderBy(i => i.ClinicName).ToList();
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

            DoctorEditViewModel? doctorToUpdate = await (from d in _context.Doctor
                                                      join s in _context.Specialty
                                                        on d.Specialty.SpecialtyId equals s.SpecialtyId
                                                      join c in _context.Clinic
                                                        on d.Clinic.ClinicId equals c.ClinicId
                                                      where d.DoctorId == id
                                                      orderby d.FirstName
                                                      select new DoctorEditViewModel
                                                      {
                                                          DoctorId = d.DoctorId,
                                                          SpecialtyId = s.SpecialtyId,
                                                          ClinicId = c.ClinicId,
                                                          FirstName = d.FirstName,
                                                          MiddleName = d.MiddleName,
                                                          LastName = d.LastName,
                                                          DateOfBirth = d.DateOfBirth,
                                                          Gender = d.Gender,
                                                          Email = d.Email,
                                                          PhoneNumber = d.PhoneNumber
                                                      }).FirstOrDefaultAsync();

            doctorToUpdate.Specialties = _context.Specialty.OrderBy(i => i.Name).ToList();
            doctorToUpdate.Clinics = _context.Clinic.OrderBy(i => i.ClinicName).ToList();

            if (doctorToUpdate == null)
            {
                return NotFound();
            }
            return View(doctorToUpdate);
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
        public async Task<IActionResult> Edit(int id, DoctorEditViewModel doctorToUpdate)
        {
            if (id != doctorToUpdate.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Doctor? existingDoctor = await _context.Doctor
                                                            .Include(s => s.Clinic) // Include the Clinic property
                                                            .Include(s => s.Specialty) // Include the Specialty property
                                                            .FirstOrDefaultAsync(s => s.DoctorId == id);
                    if (existingDoctor == null)
                    {
                        return NotFound();
                    }

                    // Update the existingService properties
                    existingDoctor.FirstName = doctorToUpdate.FirstName;
                    existingDoctor.MiddleName = doctorToUpdate.MiddleName;
                    existingDoctor.LastName = doctorToUpdate.LastName;
                    existingDoctor.DateOfBirth = doctorToUpdate.DateOfBirth;
                    existingDoctor.Gender = doctorToUpdate.Gender;
                    existingDoctor.Email = doctorToUpdate.Email;
                    existingDoctor.PhoneNumber = doctorToUpdate.PhoneNumber;

                    // Update the clinic if it has changed
                    if (existingDoctor.Clinic.ClinicId != doctorToUpdate.ClinicId)
                    {
                        var clinic = await _context.Clinic.FindAsync(doctorToUpdate.ClinicId);
                        if (clinic == null)
                        {
                            return NotFound();
                        }

                        //existingService.Clinic.ClinicId = clinic.ClinicId;
                        existingDoctor.Clinic = clinic;
                    }

                    // Update the Specialty if it has changed
                    if (existingDoctor.Specialty.SpecialtyId != doctorToUpdate.SpecialtyId)
                    {
                        var specialty = await _context.Specialty.FindAsync(doctorToUpdate.SpecialtyId);
                        if (specialty == null)
                        {
                            return NotFound();
                        }

                        //existingService.Clinic.ClinicId = clinic.ClinicId;
                        existingDoctor.Specialty = specialty;
                    }

                    _context.Update(existingDoctor);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = $"{existingDoctor.LastName}, {existingDoctor.FirstName} was updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctorToUpdate.DoctorId))
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
            return View(doctorToUpdate);
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

            // Doctor information with their specialty and clinic
            DoctorIndexViewModel? doctorData = await (from d in _context.Doctor
                                                      join s in _context.Specialty
                                                        on d.Specialty.SpecialtyId equals s.SpecialtyId
                                                      where d.DoctorId == id
                                                      join c in _context.Clinic
                                                        on d.Clinic.ClinicId equals c.ClinicId
                                                      orderby d.FirstName
                                                      select new DoctorIndexViewModel
                                                      {
                                                          DoctorId = d.DoctorId,
                                                          SpecialtyId = s.SpecialtyId,
                                                          ClinicId = c.ClinicId,
                                                          SpecialtyName = s.Name,
                                                          ClinicName = c.ClinicName,
                                                          FirstName = d.FirstName,
                                                          MiddleName = d.MiddleName,
                                                          LastName = d.LastName,
                                                          DateOfBirth = d.DateOfBirth,
                                                          Gender = d.Gender,
                                                          Email = d.Email,
                                                          PhoneNumber = d.PhoneNumber
                                                      }).FirstOrDefaultAsync();
            if (doctorData == null)
            {
                return NotFound();
            }

            return View(doctorData);
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
        /// <summary>
        /// Finds existing Doctor object using the DoctorId
        /// </summary>
        /// <param name="id">Doctor's unique identifier</param>
        /// <returns>The Doctor object that corresponds with the DoctorId used to find it</returns>
        private bool DoctorExists(int id)
        {
            return (_context.Doctor?.Any(e => e.DoctorId == id)).GetValueOrDefault();
        }

    }
}
