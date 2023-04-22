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
        public int ServiceId { get; set; }

        /// <summary>
        /// The Fee of the Service provided
        /// </summary>
        [Display(Name = "Fee")]
        [Required(ErrorMessage = "{0} is requried.")]
        [DataType(DataType.Currency)]
        public double Fee { get; set; }

        /// <summary>
        ///  The Service's Name
        /// </summary>
        [Display(Name = "Service")]
        [Required(ErrorMessage = "{0} is requried.")]
        [StringLength(100)]
        public string? ServiceName { get; set; }

        [Display(Name = "Duration")]
        [Required(ErrorMessage = "{0} is requried.")]
        [DataType(DataType.Time)]
        public string? ServiceTime { get; set; }
    }
}
