using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a Service
    /// </summary>
    public class Service
    {
        /// <summary>
        /// The Service's unique Identity
        /// </summary>
        [Key]
        public int FeeID { get; private set; }

        /// <summary>
        /// The Service's price
        /// </summary>
        [Display(Name = "Price")]
        [Required(ErrorMessage = "{0} is requried.")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        /// <summary>
        ///  The Service's Name
        /// </summary>
        [Display(Name = "The Service's Name")]
        [Required(ErrorMessage = "{0} is requried.")]
        [StringLength(100)]
        public string? FeeName { get; set; }
    }
}
