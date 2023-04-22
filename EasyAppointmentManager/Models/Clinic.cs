using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a single Clinic
    /// </summary>
    public class Clinic
    {
        /// <summary> 
        /// The unique identifier for the clinic
        /// </summary>
        [Key]
        public int ClinicId { get; set; }

        /// <summary>
        /// The Clinic's name
        /// </summary>
        [Display(Name = "Clinic Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string ClinicName { get; set; }

        /// <summary>
        /// The Clinic's code
        /// </summary>
        [Display(Name = "Code of Specialty")]
        [StringLength(100)]
        public string? Code { get; set; }

        /// <summary>
        /// The description of the Clinic
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The Clinic's phone number
        /// </summary>
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The Clinic's email address
        /// </summary>
        [StringLength(100)]
        [Display(Name = "Email")]
        // [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        public Location? Location { get; set; }

        public ICollection<Doctor>? Doctors { get; set; }

        public ICollection<Service>? Services { get; set; }
    }
}