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
        ///  The Service's Name
        /// </summary>
        [Display(Name = "Service Name")]
        [Required(ErrorMessage = "{0} is requried.")]
        [StringLength(100)]
        public string? ServiceName { get; set; }

        [Display(Name = "Service Duration")]
        [Required(ErrorMessage = "{0} is requried.")]
        [Range(1, 6, ErrorMessage = "Service time must be between 1 and 6 hours.")]
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
    /// Represents a Service in Create View
    /// </summary>
    public class ServiceCreateViewModel
    {
        /// <summary>
        ///  The Service's Name
        /// </summary>
        [Display(Name = "Service Name")]
        [Required(ErrorMessage = "{0} is requried.")]
        [StringLength(100)]
        public string? ServiceName { get; set; }

        [Display(Name = "Service Duration")]
        [Required(ErrorMessage = "{0} is requried.")]
        [Range(1, 6, ErrorMessage = "Service time must be between 1 and 6 hours.")]
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

    /// <summary>
    /// Represents a Service in the Index View
    /// </summary>
    public class ServiceIndexViewModel
    {
        /// <summary>
        /// The Service's unique Identity
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        ///  The Service's Name
        /// </summary>
        [Display(Name = "Service Name")]
        public string? ServiceName { get; set; }

        [Display(Name = "Service Duration")]
        public int? ServiceTime { get; set; }

        /// <summary>
        /// The Fee of the Service provided
        /// </summary>
        [Display(Name = "Service Fee")]
        [DataType(DataType.Currency)]
        public double Fee { get; set; }

        [Display(Name = "Clinic")]
        public string? ClinicName { get; set; }
    }

    /// <summary>
    /// Represents a Service in Edit View
    /// </summary>
    public class ServiceEditViewModel
    {
        /// <summary>
        /// The Service's unique Identity
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        ///  The Service's Name
        /// </summary>
        [Display(Name = "Service Name")]
        [Required(ErrorMessage = "{0} is requried.")]
        [StringLength(100)]
        public string? ServiceName { get; set; }

        [Display(Name = "Service Duration")]
        [Required(ErrorMessage = "{0} is requried.")]
        [Range(1, 6, ErrorMessage = "Service time must be between 1 and 6 hours.")]
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

        [Display(Name = "Clinic")]
        public int ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
    }
}
