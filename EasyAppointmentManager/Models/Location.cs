using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a Location
    /// </summary>
    public class Location
    {
        [Key]
        public int LocationID { get; private set; }

        [Display(Name = "Address Of Location")]
        [Required(ErrorMessage = "{0} is required.")]
        public string? Address { get; set; }

        [Display(Name = "The Location's City")]
        [Required(ErrorMessage = "{0} is requried")]
        public string? City { get; set; }

        [Display(Name = "The Location's Zip Code")]
        [Required(ErrorMessage = "{0} is requried")]
        public string? ZipCode { get; set; }

        [Display(Name = "Name Of Location")]
        [Required(ErrorMessage = "{0} is requried")]
        [StringLength(100)]
        public string? LocationName { get; set; }
    }
}
