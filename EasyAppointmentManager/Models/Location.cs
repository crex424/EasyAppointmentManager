using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a Location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The Identity of the Location
        /// </summary>
        [Key]
        public int LocationId { get; set; }

        /// <summary>
        /// The Location's Address
        /// </summary>
        [Display(Name = "Address")]
        [Required(ErrorMessage = "{0} is required.")]
        public string? Address { get; set; }

        /// <summary>
        /// The Location's City of residence
        /// </summary>
        [Display(Name = "City")]
        [Required(ErrorMessage = "{0} is requried")]
        public string? City { get; set; }

        /// <summary>
        /// The Location's ZipCode
        /// </summary>
        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "{0} is requried")]
        public string? ZipCode { get; set; }

        /// <summary>
        /// The Location's Name
        /// </summary>
        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "{0} is requried")]
        [StringLength(100)]
        public string? LocationName { get; set; }
    }
}
