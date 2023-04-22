using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int DoctorID { get; private set; }

        /// <summary>
        /// The Doctor's legal first name
        /// </summary>
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string? FirstName { get; set; }

        /// <summary>
        /// The Doctor's legal last name
        /// </summary>
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string? LastName { get; set; }

        /// <summary>
        /// The Doctor's legal middle name (Optional) 
        /// </summary>
        [Display(Name = "Middle Name")]
        [StringLength(55)]
        public string? MiddleName { get; set; }

        public string FullName
        {
            get { return LastName + ", " + FirstName + " " + MiddleName; }
        }

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
        [Display(Name = "Specialization")]
        [Required(ErrorMessage = "{0} is required.")]
        public int SpecializationID { get; private set; }

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
        /// The address of the location/building the doctors works for/in
        /// </summary>
        [Display(Name = "Place Of Work")]
        public string? PlaceOfWork { get; set; }
    }
}
