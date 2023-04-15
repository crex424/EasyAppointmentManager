using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a Fee
    /// </summary>
    public class Fee
    {
        /// <summary>
        /// The Fee's unique Identity
        /// </summary>
        [Key]
        public int FeeID { get; private set; }

        /// <summary>
        /// The Fee's price
        /// </summary>
        [Display(Name = "Price")]
        [Required(ErrorMessage = "{0} is requried.")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        /// <summary>
        ///  The Fee's Name
        /// </summary>
        [Display(Name = "The Fee's Name")]
        [Required(ErrorMessage = "{0} is requried.")]
        [StringLength(100)]
        public string? FeeName { get; set; }
    }
}
