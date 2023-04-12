using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a single Specialty
    /// </summary>
    public class Specialty
    {
        /// <summary>
        /// The unique identifier for the Specialty
        /// </summary>
        [Key]
        public int SpecialtyId { get; set; }

        /// <summary>
        /// The name of the Specialty
        /// </summary>
        [Display(Name = "Name of Specialty")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// The description of the Specialty
        /// </summary>
        public string? Description { get; set; }
    }
}
