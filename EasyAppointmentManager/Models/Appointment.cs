using System.ComponentModel.DataAnnotations;

namespace EasyAppointmentManager.Models
{
    /// <summary>
    /// Represents a single Appointment
    /// </summary>
    public class Appointment
    {
        /// <summary> 
        /// The unique identifier for the appointment
        /// </summary>
        [Key]
        public int AppointmentId { get; set; }

        /// <summary>
        /// Date of the appointment
        /// </summary>
        [Display(Name = "Appointment Date")]
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Date)] // display Date picker
        public DateTime Date { get; set; }

        /// <summary>
        /// Timeslot of the appointment
        /// Assume each visit is 1 hour
        /// Every work day has 8 business hours divided into 8 timeslots
        /// </summary>
        public int Timeslot { get; set; }

        // public AppointmentStatus  { get; set; }

        public Customer Customer { get; set; }

        public Location Location { get; set; }

        // public Service Service { get; set; }

        public Doctor Doctor { get; set; }


    }
}
