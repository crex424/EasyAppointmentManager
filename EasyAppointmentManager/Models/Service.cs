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
        public int ServiceID { get; private set; }

        /// <summary>
        ///  The Service's Name
        /// </summary>
        [Display(Name = "The Service Name")]
        [Required(ErrorMessage = "{0} is requried.")]
        [StringLength(100)]
        public string? ServiceName { get; set; }

        [Display(Name = "Duration")]
        [Required(ErrorMessage = "{0} is requried.")]
        // [DataType(DataType.Time)]
        public int? ServiceTime { get; set; }

        /// <summary>
        /// The Fee of the Service provided
        /// </summary>
        [Display(Name = "Service Fee")]
        [Required(ErrorMessage = "{0} is requried.")]
        [DataType(DataType.Currency)]
        public double Fee { get; set; }

        [Display(Name = "Clinic")]
        public Clinic Clinic { get; set; }
    }

    /// <summary>
    /// Represents a Service
    /// </summary>
    public class ServiceCreateViewModel
    {
        /// <summary>
        ///  The Service's Name
        /// </summary>
        [Display(Name = "The Service Name")]
        [Required(ErrorMessage = "{0} is requried.")]
        [StringLength(100)]
        public string? ServiceName { get; set; }

        [Display(Name = "Duration")]
        [Required(ErrorMessage = "{0} is requried.")]
        // [DataType(DataType.Time)]
        public int? ServiceTime { get; set; }

        /// <summary>
        /// The Fee of the Service provided
        /// </summary>
        [Display(Name = "Service Fee")]
        [Required(ErrorMessage = "{0} is requried.")]
        [DataType(DataType.Currency)]
        public double Fee { get; set; }

        /// <summary>
        /// Grabs a list of all Clinics to choose from
        /// </summary>
        [Display(Name = "Clinic")]
        public List<Clinic>? Clinics { get; set; }

        /// <summary>
        /// Identifier for selected clinic
        /// </summary>
        public int ChosenClinic { get; set; }
    }
}
