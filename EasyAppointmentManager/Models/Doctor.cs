using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a Doctor
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// The Doctor's ID
        /// </summary>
        [Key]
        public int DoctorId { get; set; }

        /// <summary>
        /// The Doctor's legal first name
        /// </summary>
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string? FirstName { get; set; }

        /// <summary>
        /// The Doctor's legal middle name (Optional) 
        /// </summary>
        [Display(Name = "Middle Name")]
        [StringLength(55)]
        public string? MiddleName { get; set; }

        /// <summary>
        /// The Doctor's legal last name
        /// </summary>
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string? LastName { get; set; }

        /// <summary>
        /// The Doctor's legal date of birth
        /// </summary>
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The legal gender of the Doctor
        /// Female = true
        /// Male = false
        /// Other/Prefer not to answer = null
        /// </summary>
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "{0} is required.")]
        public bool? Gender { get; set; }

        /// <summary>
        /// The Doctor's specialization represented by ID
        /// </summary>
        [Display(Name = "Specialty")]
        [Required(ErrorMessage = "{0} is required.")]
        public Specialty? Specialty { get; set; }

        /// <summary>
        /// The Doctor's email address
        /// </summary>
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        /// <summary>
        /// The Doctors Phone Number
        /// </summary>
        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName + " " + MiddleName; }
        } 

        [Display(Name = "Clinic")]
        public Clinic Clinic { get; set; }

    }
    /// <summary>
    /// Allows the create doctor page to use information from objects with a relationship with doctor.
    /// This will be used to create dropdown lists to make creating Doctor objects more user friendly.
    /// </summary>
    public class DoctorCreateViewModel
    {
        /// <summary>
        /// The Doctor's legal first name
        /// </summary>
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string? FirstName { get; set; }

        /// <summary>
        /// The Doctor's legal middle name (Optional) 
        /// </summary>
        [Display(Name = "Middle Name")]
        [StringLength(55)]
        public string? MiddleName { get; set; }

        /// <summary>
        /// The Doctor's legal last name
        /// </summary>
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string? LastName { get; set; }

        /// <summary>
        /// The Doctor's legal date of birth
        /// </summary>
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The legal gender of the Doctor
        /// Female = true
        /// Male = false
        /// Other/Prefer not to answer = null
        /// </summary>
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "{0} is required.")]
        public bool? Gender { get; set; }

        /// <summary>
        /// Grabs a list of all specialties to choose from
        /// </summary>
        [Display(Name = "Specialty")]
        public List<Specialty>? Specialties { get; set; }

        /// <summary>
        /// The Doctor's email address
        /// </summary>
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        /// <summary>
        /// The Doctors Phone Number
        /// </summary>
        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Grabs a list of all Clinics to choose from
        /// </summary>
        [Display(Name = "Clinic")]
        public List<Clinic>? Clinics { get; set; }

        /// <summary>
        /// Identifier for selected specialty
        /// </summary>
        public int ChosenSpecialty { get; set; }

        /// <summary>
        /// Identifier for selected clinic
        /// </summary>

        public int ChosenClinic { get; set; }
    }

    /// <summary>
    /// Contains functionality for Doctor index page which allows the use of 
    /// data from seperate tables with relationships with Doctor
    /// </summary>
    public class DoctorIndexViewModel
    {
        /// <summary>
        /// Represents Specialty's unique identifier
        /// </summary>
        public int SpecialtyId { get; set; }

        /// <summary>
        /// Represents Clinic's uniqe identifier
        /// </summary>
        public int ClinicId { get; set; }

        /// <summary>
        /// Represents the Specialy's name
        /// </summary>
        [Display(Name = "Specialty")]
        public string? SpecialtyName { get; set; }

        /// <summary>
        /// Represents the Clinic's name
        /// </summary>
        public string? ClinicName { get; set; }

        /// <summary>
        /// The Doctor's legal first name
        /// </summary>
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// The Doctor's legal middle name
        /// </summary>
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        /// <summary>
        /// The Doctor's legal last name
        /// </summary>
        [Display(Name = "Last Name")]
        public string? LastName { get; set;}

        /// <summary>
        /// The Doctor's legal date of birth
        /// </summary>
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The legal gender of the Doctor
        /// Female = true
        /// Male = false
        /// Other/Prefer not to answer = null
        /// </summary>
        [Display(Name = "Gender")]
        public bool? Gender { get; set; }

        /// <summary>
        /// The Doctor's email address
        /// </summary>
        [Display(Name = "Email")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        /// <summary>
        /// The Doctors Phone Number
        /// </summary>
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }
}
